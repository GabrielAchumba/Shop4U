using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shop4U_Frontend.Helpers;
using Shop4U_Frontend.Models;
using Shop4U_Frontend.ViewModels.FastfoodItems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Controllers
{

    public class FastfoodItemsController : Controller
    {
        private FastfoodItemUtil itemsUtil;
        private FastfoodItemPriceUtil itemPriceUtil;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly FastfoodUtil fastfoodUtil;
        public FastfoodItemsController(IHostingEnvironment _hostingEnvironment)
        {
            this.hostingEnvironment = _hostingEnvironment;
            itemsUtil = new FastfoodItemUtil();
            fastfoodUtil = new FastfoodUtil();
            itemPriceUtil = new FastfoodItemPriceUtil();
        }

        [HttpGet]
        public async Task<IActionResult> ItemsTable()
        {

            IEnumerable<FastfoodItem> items = await itemsUtil.GetFastfoodItems();
            ListofItemsVM model = new ListofItemsVM();
            model.GetItems(items);
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateItems()
        {
            CreateItemsVM model = new CreateItemsVM();
            model.LoadCategories();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItems(CreateItemsVM model)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<FastfoodItem> itemsSaved = await itemsUtil.GetFastfoodItems();

                model.CreateItems(itemsSaved.ToList());

                for (int i = 0; i < model.models.Count; i++)
                {
                    await itemsUtil.CreateFastfoodItem(model.models[i]);
                }

                return RedirectToAction("ItemsTable");
            }


            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> AddPrices(Guid Id)
        {
            FastfoodItem item = await itemsUtil.GetFastfoodItem(Id);
            IEnumerable<FastfoodItemPrice> itemPrices = await itemPriceUtil.GetFastfoodItemPrices();

            UpdatePricesVM model = new UpdatePricesVM();
            model.GetItemPriceListByMarketGroup(itemPrices.ToList(), item, "Fastfood");



            AddPricesVM model2 = new AddPricesVM();
            IEnumerable<Fastfood> supermarkets = await fastfoodUtil.GetFastfoods();

            model2.CreateSupermarketItemPriceList(supermarkets.ToList(), Id, item, model.ItemPriceList);

            for (int i = 0; i < model2.ItemPriceList.Count; i++)
            {
                await itemPriceUtil.CreateFastfoodItemPrice(model2.ItemPriceList[i]);
            }

            return View(model2);
        }

        [HttpGet]
        public async Task<IActionResult> AddPrice(Guid Id, string Others)
        {
            var splittedChars = Others.Split("?");
            Guid Item_Id = new Guid(splittedChars[2]);
            FastfoodItem item = await itemsUtil.GetFastfoodItem(Item_Id);
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
            //FastfoodItemPrice itemPrice = new FastfoodItemPrice()
            //{
            //    Id = model.ItemPriceId,
            //    ItemId = model.ItemId,
            //    MarketName = model.MarketName,
            //    MarketGroup = model.MarketGroup,
            //    CostPrice = model.CostPrice

            //};

            FastfoodItem item = await itemsUtil.GetFastfoodItem(model.ItemId);
            FastfoodItemPrice itemPrice = await itemPriceUtil.GetFastfoodItemPrice(model.ItemPriceId);
            itemPrice.CostPrice = model.CostPrice;
            itemPrice.Name = item.Name;
            if (item.BackgrounndPicture != null)
                itemPrice.Base64String = "data:image/png;base64," + Convert.ToBase64String(item.BackgrounndPicture, 0, item.BackgrounndPicture.Length);

            await itemPriceUtil.UpdateFastfoodItemPrice(itemPrice, model.ItemPriceId);
            return RedirectToAction("UpdatePrices", new { Id = model.ItemId });

        }

        [HttpGet]
        public async Task<IActionResult> UpdatePrices(Guid Id)
        {

            FastfoodItem item = await itemsUtil.GetFastfoodItem(Id);
            IEnumerable<FastfoodItemPrice> itemPrices = await itemPriceUtil.GetFastfoodItemPrices();

            UpdatePricesVM model = new UpdatePricesVM();
            model.GetItemPriceListByMarketGroup(itemPrices.ToList(), item, "Fastfood");



            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePrice(Guid Id, string Others)
        {
            var splittedChars = Others.Split("?");
            Guid Item_Id = new Guid(splittedChars[2]);

            FastfoodItem item = await itemsUtil.GetFastfoodItem(Item_Id);
            FastfoodItemPrice itemPrice = await itemPriceUtil.GetFastfoodItemPrice(Id);

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
            //FastfoodItemPrice itemPrice = new FastfoodItemPrice()
            //{
            //    Id = model.ItemPriceId,
            //    ItemId = model.ItemId,
            //    MarketGroup = model.MarketGroup,
            //    MarketName = model.MarketName,
            //    CostPrice = model.CostPrice

            //};

            FastfoodItem item = await itemsUtil.GetFastfoodItem(model.ItemId);
            FastfoodItemPrice itemPrice = await itemPriceUtil.GetFastfoodItemPrice(model.ItemPriceId);
            itemPrice.CostPrice = model.CostPrice;
            itemPrice.Name = item.Name;
            if (item.BackgrounndPicture != null)
                itemPrice.Base64String = "data:image/png;base64," + Convert.ToBase64String(item.BackgrounndPicture, 0, item.BackgrounndPicture.Length);

            await itemPriceUtil.UpdateFastfoodItemPrice(itemPrice, model.ItemPriceId);
            return RedirectToAction("UpdatePrices", new { Id = model.ItemId });

        }


        public async Task<IActionResult> DeleteItemPrice(Guid Id, string Others)
        {

            var splittedChars = Others.Split("?");
            Guid Item_Id = new Guid(splittedChars[2]);
            FastfoodItemPrice item = await itemPriceUtil.DeleteFastfoodItemPrice(Id);

            return RedirectToAction("UpdatePrices", new { Id = Item_Id });

        }

        public async Task<IActionResult> DeleteItem(Guid Id)
        {
            IEnumerable<FastfoodItemPrice> itemprices = await itemPriceUtil.GetFastfoodItemPrices();
            List<FastfoodItemPrice> itempriceList = itemprices.ToList();
            List<FastfoodItemPrice> itempricesTobeDeleted = new List<FastfoodItemPrice>();

            for (int i = 0; i < itempriceList.Count; i++)
            {
                if (itempriceList[i].ItemId == Id)
                {
                    itempricesTobeDeleted.Add(itempriceList[i]);
                }
            }

            for (int i = 0; i < itempricesTobeDeleted.Count; i++)
            {
                FastfoodItemPrice _itemPrice = await itemPriceUtil.DeleteFastfoodItemPrice(itempricesTobeDeleted[i].Id);
            }


            FastfoodItem item = await itemsUtil.DeleteFastfoodItem(Id);

            return RedirectToAction("ItemsTable");

        }
    }
}
