using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop4U_Frontend.Helpers;

namespace Shop4U_Frontend.ViewModels
{
    public class AddPricesVM
    {
        public AddPricesVM()
        {
            objectClass = new ObjectClass();
        }

        public Guid ItemId { get; set; }

        public List<ItemPrice> ItemPriceList { get; set; }

        public ObjectClass objectClass { get; set; }

        public string ItemName { get; set; }

        public string MarketGroup { get; set; }

        public string Base64String { get; set; }

        public void CreateSupermarketItemPriceList(List<Supermarket> markets, Guid ItemId, Item item,
                                            List<ItemPrice> ItemPriceListSaved)
        {
            if (markets.Count <= 0) return;
            this.ItemId = ItemId;
            this.ItemName = item.Name;
            MarketGroup = "Supermarkets";
            if (item.BackgrounndPicture != null)
                Base64String = "data:image/png;base64," + Convert.ToBase64String(item.BackgrounndPicture, 0, item.BackgrounndPicture.Length);

            ItemPriceList = new List<ItemPrice>();


            for (int i = 0; i < markets.Count; i++)
            {
                ItemPriceList.Add(new ItemPrice());
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
                ItemPriceList[i].MarketGroup = "Supermarkets";
                ItemPriceList[i].Base64String = Base64String;


            }

        }
    }
}
