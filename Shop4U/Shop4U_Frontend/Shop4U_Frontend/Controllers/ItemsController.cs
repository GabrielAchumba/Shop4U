using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shop4U_Frontend.Helpers;
using Shop4U_Frontend.Models;
using Shop4U_Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Controllers
{
    public class ItemsController : Controller
    {
        private ItemsUtil itemsUtil;
        private ItemPriceUtil itemPriceUtil;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly SupermarketsUtil SupermarketsUtil;
        public ItemsController(IHostingEnvironment _hostingEnvironment)
        {
            this.hostingEnvironment = _hostingEnvironment;
            itemsUtil = new ItemsUtil();
            SupermarketsUtil = new SupermarketsUtil();
            itemPriceUtil = new ItemPriceUtil();
        }

        [HttpGet]
        public async Task<IActionResult> ItemsTable()
        {

            IEnumerable<Item> items = await itemsUtil.GetItemsAdmin();
            ListofItemsVM model = new ListofItemsVM();
            model.GetItems(items);
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateItems()
        {
            CreateItemsVM model = new CreateItemsVM();
            model.LoadCategories();
            model.LoadFreshFoodGroups();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItems(CreateItemsVM model)
        {
            if(ModelState.IsValid)
            {
                IEnumerable<Item> itemsSaved = await itemsUtil.GetItemsAdmin();

                model.CreateItems(itemsSaved.ToList());

                for (int i = 0; i < model.models.Count; i++)
                {
                    await itemsUtil.CreateItem(model.models[i]);
                }

                return RedirectToAction("ItemsTable", "Items");
            }
            

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> AddPrices(Guid Id)
        {
            Item item = await itemsUtil.GetItemAdmin(Id);
            IEnumerable<ItemPrice> itemPrices = await itemPriceUtil.GetItemPricesAdim();

            UpdatePricesVM model = new UpdatePricesVM();
            model.GetItemPriceListByMarketGroup(itemPrices.ToList(), item, "Supermarkets");


           
            AddPricesVM model2 = new AddPricesVM();
            IEnumerable<Supermarket> supermarkets = await SupermarketsUtil.GetSupermarketsAdim();
            
            model2.CreateSupermarketItemPriceList(supermarkets.ToList(), Id, item, model.ItemPriceList);

            for (int i = 0; i < model2.ItemPriceList.Count; i++)
            {
                await itemPriceUtil.CreateItemPrice(model2.ItemPriceList[i]);
            }

            return View(model2);
        }

        [HttpGet]
        public async Task<IActionResult> AddPrice(Guid Id, string Others)
        {
            var splittedChars = Others.Split("?");
            Guid Item_Id = new Guid(splittedChars[2]);
            Item item = await itemsUtil.GetItemAdmin(Item_Id);
            AddPriceVM addPriceVM = new AddPriceVM();
            addPriceVM.ItemId = Item_Id;
            addPriceVM.ItemName = item.Name;
            addPriceVM.MarketName = splittedChars[0];
            addPriceVM.MarketGroup = splittedChars[1];
            addPriceVM.ItemPriceId = Id;
            return View(addPriceVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddPrice(AddPriceVM model)
        {
            //ItemPrice itemPrice = new ItemPrice()
            //{
            //    Id = model.ItemPriceId,
            //    ItemId = model.ItemId,
            //    MarketName = model.MarketName,
            //    MarketGroup = model.MarketGroup,
            //    CostPrice = model.CostPrice

            //};

            Item item = await itemsUtil.GetItemAdmin(model.ItemId);
            ItemPrice itemPrice = await itemPriceUtil.GetItemPriceAdim(model.ItemPriceId);
            itemPrice.CostPrice = model.CostPrice;
            itemPrice.Name = item.Name;
            if (item.BackgrounndPicture != null)
                itemPrice.Base64String = "data:image/png;base64," + Convert.ToBase64String(item.BackgrounndPicture, 0, item.BackgrounndPicture.Length);
            await itemPriceUtil.UpdateItemPrice(itemPrice, model.ItemPriceId);
            return RedirectToAction("UpdatePrices", new { Id = model.ItemId });

        }

        [HttpGet]
        public async Task<IActionResult> UpdatePrices(Guid Id)
        {
           
            Item item = await itemsUtil.GetItemAdmin(Id);
            IEnumerable<ItemPrice> itemPrices = await itemPriceUtil.GetItemPricesAdim();

            UpdatePricesVM model = new UpdatePricesVM();
            model.GetItemPriceListByMarketGroup(itemPrices.ToList(), item, "Supermarkets");

           

            return View(model);
        }   

        [HttpGet]
        public async Task<IActionResult> UpdatePrice(Guid Id, string Others)
        {
            var splittedChars = Others.Split("?");
            Guid Item_Id = new Guid(splittedChars[2]);

            Item item = await itemsUtil.GetItemAdmin(Item_Id);
            ItemPrice itemPrice = await itemPriceUtil.GetItemPriceAdim(Id);

            UpdatePriceVM updatePriceVM = new UpdatePriceVM();
            updatePriceVM.ItemName = item.Name;
            updatePriceVM.MarketName = splittedChars[0];
            updatePriceVM.MarketGroup = splittedChars[1];
            updatePriceVM.CostPrice = itemPrice.CostPrice;
            updatePriceVM.ItemId = Item_Id;
            updatePriceVM.ItemPriceId = Id;
            return View(updatePriceVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePrice(AddPriceVM model)
        {
            //ItemPrice itemPrice = new ItemPrice()
            //{
            //    Id = model.ItemPriceId,
            //    ItemId = model.ItemId,
            //    MarketGroup = model.MarketGroup,
            //    MarketName=model.MarketName,
            //    CostPrice = model.CostPrice

            //};

            Item item = await itemsUtil.GetItemAdmin(model.ItemId);
            ItemPrice itemPrice = await itemPriceUtil.GetItemPriceAdim(model.ItemPriceId);
            itemPrice.CostPrice = model.CostPrice;
            itemPrice.Name = item.Name;
            if (item.BackgrounndPicture != null)
                itemPrice.Base64String = "data:image/png;base64," + Convert.ToBase64String(item.BackgrounndPicture, 0, item.BackgrounndPicture.Length);
            await itemPriceUtil.UpdateItemPrice(itemPrice, model.ItemPriceId);
            return RedirectToAction("UpdatePrices", new { Id = model.ItemId });

        }


        public async Task<IActionResult> DeleteItemPrice(Guid Id, string Others)
        {
            
                var splittedChars = Others.Split("?");
                Guid Item_Id = new Guid(splittedChars[2]);
                ItemPrice item = await itemPriceUtil.DeletItemPrice(Id);

                return RedirectToAction("UpdatePrices", new { Id = Item_Id });
           
        }

        public async Task<IActionResult> DeleteItem(Guid Id)
        {
            IEnumerable<ItemPrice> itemprices = await itemPriceUtil.GetItemPricesAdim();
            List<ItemPrice> itempriceList = itemprices.ToList();
            List<ItemPrice> itempricesTobeDeleted = new List<ItemPrice>();

            for (int i = 0; i < itempriceList.Count; i++)
            {
                if(itempriceList[i].ItemId == Id)
                {
                    itempricesTobeDeleted.Add(itempriceList[i]);
                }
            }

            for (int i = 0; i < itempricesTobeDeleted.Count; i++)
            {
                ItemPrice _itemPrice = await itemPriceUtil.DeletItemPrice(itempricesTobeDeleted[i].Id);
            }

         
            Item item = await itemsUtil.DeletItem(Id);

            return RedirectToAction("ItemsTable");

        }
    }
}
