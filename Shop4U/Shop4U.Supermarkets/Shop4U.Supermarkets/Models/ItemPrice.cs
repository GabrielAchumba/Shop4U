using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Models
{
    public class ItemPrice: BaseModel
    {
        public ItemPrice():base()
        {

        }
        public string CostPrice { get; set; }
        public Guid ItemId { get; set; }
        public Guid MarketId { get; set; }
        public string MarketGroup { get; set; }
        public string MarketName { get; set; }
    }
}
