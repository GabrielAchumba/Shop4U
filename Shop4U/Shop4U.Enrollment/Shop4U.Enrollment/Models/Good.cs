using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Models
{
    public class Good
    {
        public Good()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public string SharedCategory { get; set; }
        public string CustomersIds { get; set; } //CustomersTickeksIds

        public int DistributionDay { get; set; }
        public int DistributionMonth { get; set; }
        public int DistributionYear { get; set; }
        public string ItemStatus { get; set; }
        public bool IsSold { get; set; }
        public double ActualPrice { get; set; }
        public Guid AdminId { get; set; }
        public string ItemCategory { get; set; }
    }
}
