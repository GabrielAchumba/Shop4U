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
                if(itemPrices[i].MarketName == SupermarketName
                    && string.IsNullOrEmpty(itemPrices[i].CostPrice) == false
                     && string.IsNullOrEmpty(itemPrices[i].Name) == false
                     && string.IsNullOrEmpty(itemPrices[i].Base64String) == false)
                {
                    ItemPrices.Add(itemPrices[i]);
                }
            }

        }
    }
}
