using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop4U_Frontend.Helpers;
using Shop4U_Frontend.Models;
using Shop4U_Frontend.ViewModels.Supermarkets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Controllers
{
    public class SupermarketsController: Controller
    {
        private readonly ListofSupermarketsVM listofSupermarketsVM;
        private  ListofSupermarketsAdminVM listofSupermarketsAdminVM;
        private  CreateSupermarketVM CreateSupermarketVM;
        private readonly SupermarketsUtil SupermarketsUtil;
        private readonly IHostingEnvironment hostingEnvironment;
        public SupermarketsController(IHostingEnvironment _hostingEnvironment)
        {
            hostingEnvironment = _hostingEnvironment;
            listofSupermarketsVM = new ListofSupermarketsVM();
            SupermarketsUtil = new SupermarketsUtil();
            CreateSupermarketVM = new CreateSupermarketVM();
        }

        [HttpGet]
        public async Task<IActionResult> ListofSupermarkets()
        {

            IEnumerable<Supermarket> supermarkets = await SupermarketsUtil.GetSupermarketsAdim();
            listofSupermarketsAdminVM = new ListofSupermarketsAdminVM(supermarkets);
            return View(listofSupermarketsAdminVM);
        }

        [HttpGet]
        public async Task<IActionResult> ListofSupermarketsAdmin()
        {
            IEnumerable<Supermarket> supermarkets = await SupermarketsUtil.GetSupermarketsAdim();
            listofSupermarketsAdminVM = new ListofSupermarketsAdminVM(supermarkets);
            return View(listofSupermarketsAdminVM);
        }

        [HttpGet]
        public IActionResult CreateSupermarket()
        {
            return View(CreateSupermarketVM);
        }

        [HttpGet]
        public async Task<IActionResult> EditSupermarket(Guid Id)
        {
            StoreId.ActiveSupermarket_Id = Id;
            Supermarket supermarket = await SupermarketsUtil.GetSupermarketAdmin(Id);
            if (CreateSupermarketVM == null) CreateSupermarketVM = new CreateSupermarketVM();
            CreateSupermarketVM.Name = supermarket.Name;
            CreateSupermarketVM.Description = supermarket.Description;
            CreateSupermarketVM.BackgrounndPicture = supermarket.BackgrounndPicture;
            return View(CreateSupermarketVM);
        }

        
        [HttpPost]
        public async Task<IActionResult> PreviewEditSupermarket(CreateSupermarketVM createSupermarketVM)
        {

            if (createSupermarketVM.Attachment != null)
            {
                var fileName = Path.Combine(hostingEnvironment.WebRootPath, Path.GetFileName(createSupermarketVM.Attachment.FileName));
                createSupermarketVM.Attachment.CopyTo(new FileStream(fileName, FileMode.Create));
                createSupermarketVM.FileLocation = "~/" + Path.GetFileName(createSupermarketVM.Attachment.FileName);                
                createSupermarketVM.BackgrounndPicture = ConvertToBytes(createSupermarketVM.Attachment);
                createSupermarketVM.Base64String = "data:image/png;base64,"
                    + Convert.ToBase64String(createSupermarketVM.BackgrounndPicture, 0,
                    createSupermarketVM.BackgrounndPicture.Length);
                Supermarket supermarket = createSupermarketVM.CreateSupermarket();
                supermarket.Id = StoreId.ActiveSupermarket_Id;
                supermarket = await SupermarketsUtil.UpdateSupermarket(supermarket, StoreId.ActiveSupermarket_Id);
                return View(createSupermarketVM);

            }
            if (createSupermarketVM.Attachment == null && CreateSupermarketVM.BackgrounndPicture != null)
            {
                createSupermarketVM.Base64String = "data:image/png;base64,"
                    + Convert.ToBase64String(CreateSupermarketVM.BackgrounndPicture, 0,
                    CreateSupermarketVM.BackgrounndPicture.Length);
                Supermarket supermarket = CreateSupermarketVM.CreateSupermarket();
                supermarket.Id = StoreId.ActiveSupermarket_Id;
                supermarket = await SupermarketsUtil.UpdateSupermarket(supermarket, StoreId.ActiveSupermarket_Id);
                return View(createSupermarketVM);
            }
           

            if (CreateSupermarketVM == null) CreateSupermarketVM = new CreateSupermarketVM();
            return View(CreateSupermarketVM);
        }

        [HttpPost]
        public async Task<IActionResult> PreviewSupermarket(CreateSupermarketVM createSupermarketVM)
        {
            
            if(createSupermarketVM.Attachment != null)
            {
                var fileName = Path.Combine(hostingEnvironment.WebRootPath, Path.GetFileName(createSupermarketVM.Attachment.FileName));
                createSupermarketVM.Attachment.CopyTo(new FileStream(fileName, FileMode.Create));
                createSupermarketVM.FileLocation ="~/" + Path.GetFileName(createSupermarketVM.Attachment.FileName);
                createSupermarketVM.BackgrounndPicture = ConvertToBytes(createSupermarketVM.Attachment);
                Supermarket supermarket = createSupermarketVM.CreateSupermarket();
                CreateSupermarketVM = createSupermarketVM;
               supermarket = await SupermarketsUtil.CreateSupermarket(supermarket);

            }
            return View(createSupermarketVM);
        }


        public async Task<IActionResult> DeleteSupermarket(Guid Id)
        {
            if (ModelState.IsValid)
            {
                Supermarket supermarket = await SupermarketsUtil.DeletSupermarket(Id);

                return RedirectToAction("ListofSupermarketsAdmin");
            }


            return RedirectToAction("ListofSupermarketsAdmin");
        }
        private byte[] ConvertToBytes(IFormFile image)
        {
            byte[] CoverImageBytes = null;
            BinaryReader reader = new BinaryReader(image.OpenReadStream());
            CoverImageBytes = reader.ReadBytes((int)image.Length);
            return CoverImageBytes;
        }

        public FileResult GetFileFromBytes(byte[] bytesIn)
        {
            try
            {
                return File(bytesIn, "image/png");

            }
            catch 
            {

                return null;
            }
        }

        [HttpGet]
        public  IActionResult GetUserImageFile(byte[] BackgrounndPicture)
        {
            //    FileResult imageUserFile = new FileResult();
            //    if (CreateSupermarketVM.BackgrounndPicture == null) return null;
            if (BackgrounndPicture == null) BackgrounndPicture = new byte[10];
             FileResult imageUserFile = GetFileFromBytes(BackgrounndPicture);
            return imageUserFile;
        }
        

    }
}
