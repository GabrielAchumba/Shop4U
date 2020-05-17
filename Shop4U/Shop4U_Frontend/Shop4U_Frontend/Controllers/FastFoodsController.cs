using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop4U_Frontend.Helpers;
using Shop4U_Frontend.Models;
using Shop4U_Frontend.ViewModels;
using Shop4U_Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Controllers
{

    public class FastFoodsController : Controller
    {
        private FastfoodItemPriceUtil itemPriceUtil;
        private ListofFastfoodsVM listofFastfoodsVM;
        private ListofFastfoodsAdminVM listofFastfoodsAdminVM;
        private CreateFastfoodVM createFastfoodVM;
        private  FastfoodUtil fastfoodUtil;
        private  IHostingEnvironment hostingEnvironment;
        private FastfoodCartUtil fastfoodCartUtil;
        private AddToFastfoodCartVM addToFastfoodCartVM;
        public FastFoodsController(IHostingEnvironment _hostingEnvironment)
        {
            hostingEnvironment = _hostingEnvironment;
            fastfoodUtil = new FastfoodUtil();
            createFastfoodVM = new CreateFastfoodVM();
            itemPriceUtil = new FastfoodItemPriceUtil();
            fastfoodCartUtil = new FastfoodCartUtil();
            addToFastfoodCartVM = new AddToFastfoodCartVM();
        }

        [HttpGet]
        public async Task<IActionResult> ListofFastfoods()
        {

            IEnumerable<Fastfood> fastfoods = await fastfoodUtil.GetFastfoods();
            listofFastfoodsVM = new ListofFastfoodsVM(fastfoods);
            return View(listofFastfoodsVM);
        }

        [HttpGet]
        public async Task<IActionResult> ListofFastfoodsAdmin()
        {
            IEnumerable<Fastfood> fastfoods = await fastfoodUtil.GetFastfoods();
            listofFastfoodsAdminVM = new ListofFastfoodsAdminVM(fastfoods);
            return View(listofFastfoodsAdminVM);
        }

        [HttpGet]
        public IActionResult CreateFastfood()
        {
            return View(createFastfoodVM);
        }

        [HttpGet]
        public async Task<IActionResult> EditFastfood(Guid Id)
        {
            StoreId.ActiveSupermarket_Id = Id;
            Fastfood fastfood = await fastfoodUtil.GetFastfood(Id);
            if (createFastfoodVM == null) createFastfoodVM = new CreateFastfoodVM();
            createFastfoodVM.Name = fastfood.Name;
            createFastfoodVM.Description = fastfood.Description;
            createFastfoodVM.BackgrounndPicture = fastfood.BackgrounndPicture;
            return View(createFastfoodVM);
        }


        [HttpPost]
        public async Task<IActionResult> PreviewEditFastfood(CreateFastfoodVM _createFastfoodVM)
        {

            if (_createFastfoodVM.Attachment != null)
            {
                var fileName = Path.Combine(hostingEnvironment.WebRootPath, Path.GetFileName(_createFastfoodVM.Attachment.FileName));
                _createFastfoodVM.Attachment.CopyTo(new FileStream(fileName, FileMode.Create));
                _createFastfoodVM.FileLocation = "~/" + Path.GetFileName(_createFastfoodVM.Attachment.FileName);
                _createFastfoodVM.BackgrounndPicture = ConvertToBytes(_createFastfoodVM.Attachment);
                _createFastfoodVM.Base64String = "data:image/png;base64,"
                    + Convert.ToBase64String(_createFastfoodVM.BackgrounndPicture, 0,
                    _createFastfoodVM.BackgrounndPicture.Length);
                Fastfood fastfood  = _createFastfoodVM.CreateFastfood();
                fastfood.Id = StoreId.ActiveSupermarket_Id;
                fastfood = await fastfoodUtil.UpdateFastfood(fastfood, StoreId.ActiveSupermarket_Id);
                return View(_createFastfoodVM);

            }
            if (createFastfoodVM.Attachment == null && createFastfoodVM.BackgrounndPicture != null)
            {
                createFastfoodVM.Base64String = "data:image/png;base64,"
                    + Convert.ToBase64String(createFastfoodVM.BackgrounndPicture, 0,
                    createFastfoodVM.BackgrounndPicture.Length);
                Fastfood fastfood  = createFastfoodVM.CreateFastfood();
                fastfood.Id = StoreId.ActiveSupermarket_Id;
                fastfood = await fastfoodUtil.UpdateFastfood(fastfood, StoreId.ActiveSupermarket_Id);
                return View(createFastfoodVM);
            }


            if (createFastfoodVM == null) createFastfoodVM = new CreateFastfoodVM();
            return View(createFastfoodVM);
        }

        [HttpPost]
        public async Task<IActionResult> PreviewFastfood(CreateFastfoodVM _createFastfoodVM)
        {

            if (_createFastfoodVM.Attachment != null)
            {
                var fileName = Path.Combine(hostingEnvironment.WebRootPath, Path.GetFileName(_createFastfoodVM.Attachment.FileName));
                _createFastfoodVM.Attachment.CopyTo(new FileStream(fileName, FileMode.Create));
                _createFastfoodVM.FileLocation = "~/" + Path.GetFileName(_createFastfoodVM.Attachment.FileName);
                _createFastfoodVM.BackgrounndPicture = ConvertToBytes(_createFastfoodVM.Attachment);
                Fastfood fastfood   = _createFastfoodVM.CreateFastfood();
                createFastfoodVM = _createFastfoodVM;
                await fastfoodUtil.CreateFastfood(fastfood);

            }
            return View(createFastfoodVM);
        }


        public async Task<IActionResult> DeleteFastfood(Guid Id)
        {
            if (ModelState.IsValid)
            {
                Fastfood fastfood  = await fastfoodUtil.DeleteFastfood(Id);

                return RedirectToAction("ListofFastfoodsAdmin");
            }


            return RedirectToAction("ListofFastfoodsAdmin");
        }

        [HttpGet]
        public async Task<IActionResult> EnterFastfood(Guid Id)
        {
            Fastfood fastfood  = await fastfoodUtil.GetFastfood(Id);
            IEnumerable<FastfoodItemPrice> itemPrices = await itemPriceUtil.GetFastfoodItemPrices();
            EnterFastfoodVM enterFastfoodVM = new EnterFastfoodVM();
            enterFastfoodVM.CreateViewModel(fastfood, itemPrices.ToList());

            return View(enterFastfoodVM);
        }


        public async Task<IActionResult> AddToCart(Guid Id, string Others)
        {
            var splittedChars = Others.Split("?");
            string MarketName = splittedChars[0];
            string CostPrice = splittedChars[1];
            string ItemName = splittedChars[2];
            FastfoodCart fastfoodCart = new FastfoodCart()
            {
                MarketName = MarketName,
                CostPrice = CostPrice,
                ItemName = ItemName,
                Day = DateTime.Now.Day,
                Month = DateTime.Now.Month,
                Year = DateTime.Now.Year,
                IsPaid = false,
                PhoneNumber = "07032488605",
                CustomerId = StoreId.ActiveUser_Id
            };

            await fastfoodCartUtil.CreateFastfoodCart(fastfoodCart);
            var fastfoodcarts = await fastfoodCartUtil.GetFastfoodCarts();
            addToFastfoodCartVM.CreateFastfoodcarts(fastfoodCart, fastfoodcarts.ToList());

            return View(addToFastfoodCartVM);
        }

        public async Task<IActionResult> RefreshOrders(Guid Id, string Others)
        {
            var splittedChars = Others.Split("?");
            string MarketName = splittedChars[0];
            string CostPrice = splittedChars[1];
            string ItemName = splittedChars[2];
            FastfoodCart fastfoodCart = new FastfoodCart()
            {
                MarketName = MarketName,
                CostPrice = CostPrice,
                ItemName = ItemName,
                Day = DateTime.Now.Day,
                Month = DateTime.Now.Month,
                Year = DateTime.Now.Year,
                IsPaid = false,
                PhoneNumber = "07032488605",
                CustomerId = StoreId.ActiveUser_Id
            };

            var fastfoodcarts = await fastfoodCartUtil.GetFastfoodCarts();
            addToFastfoodCartVM.CreateFastfoodcarts(fastfoodCart, fastfoodcarts.ToList());

            return View(addToFastfoodCartVM);
        }

        public async Task<IActionResult> DeleteOrder(Guid Id)
        {
            FastfoodCart fastfoodCart  = await fastfoodCartUtil.GetFastfoodCart(Id);
            string others = fastfoodCart.MarketName + "?" +
                fastfoodCart.CostPrice + "?" + fastfoodCart.ItemName;

            var result = await fastfoodCartUtil.DeleteFastfoodCart(Id);

            return RedirectToAction("RefreshOrders", new { Id = Guid.NewGuid(), Others = others });
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
        public IActionResult GetUserImageFile(byte[] BackgrounndPicture)
        {
            //    FileResult imageUserFile = new FileResult();
            //    if (CreateSupermarketVM.BackgrounndPicture == null) return null;
            if (BackgrounndPicture == null) BackgrounndPicture = new byte[10];
            FileResult imageUserFile = GetFileFromBytes(BackgrounndPicture);
            return imageUserFile;
        }


    }
}
