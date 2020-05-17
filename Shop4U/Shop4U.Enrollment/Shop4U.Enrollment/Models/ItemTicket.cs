using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Models
{
    public class ItemTicket
    {
        public ItemTicket()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ItemId { get; set; }

        public double Cost { get; set; }
        public bool IsPaid { get; set; }
    }
}
