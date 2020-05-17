using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Models
{
    public class FastfoodItemPrice : BaseModel
    {
        public FastfoodItemPrice() : base()
        {

        }
        public string CostPrice { get; set; }
        public Guid ItemId { get; set; }
        public Guid MarketId { get; set; }
        public string MarketGroup { get; set; }
        public string MarketName { get; set; }
    }
}
