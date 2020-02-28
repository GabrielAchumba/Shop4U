using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels
{
    public class EnterSupermarketVM
    {
        public EnterSupermarketVM()
        {

        }

        public string SupermarketName { get; set; }
        public List<ItemPrice> ItemPrices { get; set; }
        public void CreateViewModel(Supermarket supermarket, List<ItemPrice> itemPrices)
        {
            SupermarketName = supermarket.Name;
            ItemPrices = new List<ItemPrice>();
            for (int i = 0; i < itemPrices.Count; i++)
            {
                if(itemPrices[i].MarketName == SupermarketName)
                {
                    ItemPrices.Add(itemPrices[i]);
                }
            }

        }
    }
}
