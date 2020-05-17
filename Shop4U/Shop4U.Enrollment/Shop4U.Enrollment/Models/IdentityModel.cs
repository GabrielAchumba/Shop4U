using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Models
{
    public class IdentityModel
    {
        public string PhoneNumber { get; set; }
        public bool IsLogin { get; set; }

        public override string ToString()
        {
            return PhoneNumber;
        }
    }
}
