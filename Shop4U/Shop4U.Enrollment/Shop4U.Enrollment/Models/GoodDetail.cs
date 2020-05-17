using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Models
{
    public class GoodDetail
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public string Price { get; set; }
        public string ContentSize { get; set; }
        public int Units { get; set; }
        public double CostPrice { get; set; }
        public string ItemCategory { get; set; }
    }
}
