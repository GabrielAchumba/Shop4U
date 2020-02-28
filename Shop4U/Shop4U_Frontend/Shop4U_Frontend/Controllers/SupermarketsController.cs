using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop4U_Frontend.Helpers;
using Shop4U_Frontend.Models;
using Shop4U_Frontend.ViewModels;
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
        private ItemPriceUtil itemPriceUtil;
        private  ListofSupermarketsVM listofSupermarketsVM;
        private  ListofSupermarketsAdminVM listofSupermarketsAdminVM;
        private  CreateSupermarketVM CreateSupermarketVM;
        private readonly SupermarketsUtil SupermarketsUtil;
        private readonly IHostingEnvironment hostingEnvironment;
        private SupermarketCartUtil supermarketCartUtil;
        private AddToCartVM addToCartVM;
        public SupermarketsController(IHostingEnvironment _hostingEnvironment)
        {
            hostingEnvironment = _hostingEnvironment;
            SupermarketsUtil = new SupermarketsUtil();
            CreateSupermarketVM = new CreateSupermarketVM();
            itemPriceUtil = new ItemPriceUtil();
            supermarketCartUtil = new SupermarketCartUtil();
            addToCartVM = new AddToCartVM();
        }

        [HttpGet]
        public async Task<IActionResult> ListofSupermarkets()
        {

            IEnumerable<Supermarket> supermarkets = await SupermarketsUtil.GetSupermarketsAdim();
            listofSupermarketsVM = new ListofSupermarketsVM(supermarkets);
            return View(listofSupermarketsVM);
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

        [HttpGet]
        public async Task<IActionResult> EnterSupermarket(Guid Id)
        {
            Supermarket supermarket = await SupermarketsUtil.GetSupermarketAdmin(Id);
            IEnumerable<ItemPrice> itemPrices = await itemPriceUtil.GetItemPricesAdim();
            EnterSupermarketVM enterSupermarketVM = new EnterSupermarketVM();
            enterSupermarketVM.CreateViewModel(supermarket, itemPrices.ToList());

            return View(enterSupermarketVM);
        }

        
        public async Task<IActionResult> AddToCart(Guid Id, string Others)
        {
            var splittedChars = Others.Split("?");
            string MarketName = splittedChars[0];
            string CostPrice = splittedChars[1];
            string ItemName = splittedChars[2];
            SupermarketCart supermarketCart = new SupermarketCart()
            {
                MarketName = MarketName,
                CostPrice = CostPrice,
                ItemName = ItemName,
                Day=DateTime.Now.Day,
                Month=DateTime.Now.Month,
                Year=DateTime.Now.Year,
                IsPaid=false,
                PhoneNumber="07032488605",
                CustomerId= StoreId.ActiveUser_Id
            };

            await supermarketCartUtil.CreateSupermarketCart(supermarketCart);
            var supermarketcarts = await supermarketCartUtil.GetSupermarketCarts();
            addToCartVM.CreateSupermarketcarts(supermarketCart, supermarketcarts.ToList());

            return View(addToCartVM);
        }

        public async Task<IActionResult> RefreshOrders(Guid Id, string Others)
        {
            var splittedChars = Others.Split("?");
            string MarketName = splittedChars[0];
            string CostPrice = splittedChars[1];
            string ItemName = splittedChars[2];
            SupermarketCart supermarketCart = new SupermarketCart()
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

            var supermarketcarts = await supermarketCartUtil.GetSupermarketCarts();
            addToCartVM.CreateSupermarketcarts(supermarketCart, supermarketcarts.ToList());

            return View(addToCartVM);
        }

        public async Task<IActionResult> DeleteOrder(Guid Id)
        {
            SupermarketCart supermarketCart = await supermarketCartUtil.GetSupermarketCart(Id);
            string others = supermarketCart.MarketName + "?" +
                supermarketCart.CostPrice + "?" + supermarketCart.ItemName;

            var result = await supermarketCartUtil.DeleteSupermarketCart(Id);
            
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
