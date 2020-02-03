using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Models
{
    public class Item : BaseModel
    {
        public Guid ItemCartegoryId { get; set; }
        public Guid ItemGroupId { get; set; }
        public Guid ItemTypeId { get; set; }
        public double Price { get; set; }
    }
}
