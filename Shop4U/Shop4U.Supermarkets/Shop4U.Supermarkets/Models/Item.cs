using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Models
{
    public class Item : BaseModel
    {
        public string ItemCartegoryName { get; set; }
        public string ItemGroupName { get; set; }
        public string ItemTypeName { get; set; }
        public double Price { get; set; }
    }
}
