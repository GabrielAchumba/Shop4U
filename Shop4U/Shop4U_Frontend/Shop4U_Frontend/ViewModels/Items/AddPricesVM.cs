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

        public void CreateSupermarketItemPriceList(List<Supermarket> markets,Guid ItemId,Item item)
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

                    ItemPriceList.Add(new ItemPrice()
                    {
                        Name= item.Name,
                        MarketId= markets[i].Id,
                        ItemId= ItemId,
                        MarketName= markets[i].Name,
                        MarketGroup = "Supermarkets"
                    });

                }
           
        }
    }
}
