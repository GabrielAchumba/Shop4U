using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Fastfoods.Models
{
    public class FastfoodCart:BaseModel
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Time { get; set; }
        public string ItemName { get; set; }
        public string MarketName { get; set; }
        public string CostPrice { get; set; }
        public string PhoneNumber { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsPaid { get; set; }
    }
}
