using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels.FastfoodItems
{
    public class AddPriceVM
    {
        public AddPriceVM()
        {
            
        }
        public Guid ItemId { get; set; }
        public Guid ItemPriceId { get; set; }
        public string ItemName { get; set; }
        public string MarketName { get; set; }
        public string MarketGroup { get; set; }
        public string CostPrice { get; set; }
        

      

    }
}
