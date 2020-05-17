using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels
{
    public class EnterFastfoodVM
    {
        public EnterFastfoodVM()
        {

        }

        public string FastfoodName { get; set; }
        public List<FastfoodItemPrice> ItemPrices { get; set; }
        public void CreateViewModel(Fastfood fastfood, List<FastfoodItemPrice> itemPrices)
        {
            FastfoodName = fastfood.Name;
            ItemPrices = new List<FastfoodItemPrice>();
            for (int i = 0; i < itemPrices.Count; i++)
            {
                if(itemPrices[i].MarketName == FastfoodName && string.IsNullOrEmpty(itemPrices[i].CostPrice) == false)
                {
                    ItemPrices.Add(itemPrices[i]);
                }
            }

        }
    }
}
