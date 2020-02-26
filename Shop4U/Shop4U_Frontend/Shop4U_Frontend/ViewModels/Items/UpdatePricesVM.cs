using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels
{
    public class UpdatePricesVM
    {
        public UpdatePricesVM()
        {
            ItemName = "";
            MarketName = "";
            Base64String = "";
            ItemPriceList = new List<ItemPrice>();
        }

        public Guid ItemId { get; set; }
        public string ItemName { get; set; }
        public string MarketName { get; set; }
        public string MarketGroup { get; set; }
        public string Base64String { get; set; }
        public List<ItemPrice> ItemPriceList { get; set; }
        public void GetItemPriceListByMarketGroup(List<ItemPrice> itemPrices, Item item, string MarketGroup)
        {
            if (itemPrices.Count <= 0) return;

            ItemId = item.Id;
            this.ItemName = item.Name;
            this.MarketGroup = MarketGroup;
            if (item.BackgrounndPicture != null)
                Base64String = "data:image/png;base64," + Convert.ToBase64String(item.BackgrounndPicture, 0, item.BackgrounndPicture.Length);

            ItemPriceList = new List<ItemPrice>();


            for (int i = 0; i < itemPrices.Count; i++)
            {
                if (this.MarketGroup == itemPrices[i].MarketGroup)
                {
                    ItemPriceList.Add(itemPrices[i]);
                }


            }

        }
    }
}
