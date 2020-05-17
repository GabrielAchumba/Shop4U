using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Fastfoods.Models
{
    public class FastfoodItem: BaseModel
    {
        public FastfoodItem() : base()
        {

        }
        public string ItemCartegoryName { get; set; }
    }
}
