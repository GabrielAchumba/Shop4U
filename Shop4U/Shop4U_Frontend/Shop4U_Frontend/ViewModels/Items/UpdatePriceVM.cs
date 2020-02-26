using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels
{
    public class UpdatePriceVM
    {
        public UpdatePriceVM()
        {
            ItemName = "";
            MarketName = "";
            CostPrice = "";
            ItemId = Guid.NewGuid();
        }

        public Guid ItemPriceId { get; set; }
        public Guid ItemId { get; set; }
        public string ItemName { get; set; }
        public string MarketName { get; set; }
        public string MarketGroup { get; set; }
        public string CostPrice { get; set; }
    }
}
