using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels.FastfoodItems
{
    public class UpdatePricesVM
    {
        public UpdatePricesVM()
        {
            ItemName = "";
            MarketName = "";
            Base64String = "";
            ItemPriceList = new List<FastfoodItemPrice>();
        }

        public Guid ItemId { get; set; }
        public string ItemName { get; set; }
        public string MarketName { get; set; }
        public string MarketGroup { get; set; }
        public string Base64String { get; set; }
        public List<FastfoodItemPrice> ItemPriceList { get; set; }
        public void GetItemPriceListByMarketGroup(List<FastfoodItemPrice> itemPrices, FastfoodItem item, string MarketGroup)
        {
            if (itemPrices.Count <= 0) return;

            ItemId = item.Id;
            this.ItemName = item.Name;
            this.MarketGroup = MarketGroup;
            if (item.BackgrounndPicture != null)
                Base64String = "data:image/png;base64," + Convert.ToBase64String(item.BackgrounndPicture, 0, item.BackgrounndPicture.Length);

            ItemPriceList = new List<FastfoodItemPrice>();


            for (int i = 0; i < itemPrices.Count; i++)
            {
                if (ItemId == itemPrices[i].ItemId)
                {
                    itemPrices[i].Base64String = Base64String;
                    itemPrices[i].Name = this.ItemName;
                    ItemPriceList.Add(itemPrices[i]);
                }


            }

        }
    }
}
