using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop4U_Frontend.Helpers;

namespace Shop4U_Frontend.ViewModels.FastfoodItems
{
    public class AddPricesVM
    {
        public AddPricesVM()
        {

        }

        public Guid ItemId { get; set; }

        public List<FastfoodItemPrice> ItemPriceList { get; set; }


        public string ItemName { get; set; }

        public string MarketGroup { get; set; }

        public string Base64String { get; set; }

        public void CreateSupermarketItemPriceList(List<Fastfood> markets, Guid ItemId, FastfoodItem item,
                                            List<FastfoodItemPrice> ItemPriceListSaved)
        {
            if (markets.Count <= 0) return;
            this.ItemId = ItemId;
            this.ItemName = item.Name;
            MarketGroup = "Fastfood";
            if (item.BackgrounndPicture != null)
                Base64String = "data:image/png;base64," + Convert.ToBase64String(item.BackgrounndPicture, 0, item.BackgrounndPicture.Length);

            ItemPriceList = new List<FastfoodItemPrice>();


            for (int i = 0; i < markets.Count; i++)
            {
                ItemPriceList.Add(new FastfoodItemPrice());
                for (int j = 0; j < ItemPriceListSaved.Count; j++)
                {
                    if (markets[i].Name == ItemPriceListSaved[j].MarketName)
                    {
                        ItemPriceList[i] = ItemPriceListSaved[j];
                        break;
                    }
                }
            }



            for (int i = 0; i < markets.Count; i++)
            {

                ItemPriceList[i].Name = item.Name;
                ItemPriceList[i].MarketId = markets[i].Id;
                ItemPriceList[i].ItemId = ItemId;
                ItemPriceList[i].MarketName = markets[i].Name;
                ItemPriceList[i].MarketGroup = "Fastfood";
                ItemPriceList[i].Base64String = Base64String;


            }

        }
    }


}
