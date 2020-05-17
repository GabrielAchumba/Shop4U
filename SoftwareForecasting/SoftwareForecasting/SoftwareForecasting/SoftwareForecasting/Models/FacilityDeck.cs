using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareForecasting.Models
{
    public class FacilityDeck
    {
        public FacilityDeck()
        {
            id = Guid.NewGuid();
        }
        public Guid id { get; set; }
        public string Primary_Facility { get; set; }
        public string Secondary_Facility { get; set; }
        public double Liquid_Capacity { get; set; }
        public double Gas_Capacity { get; set; }
        public double Scheduled_Deferment { get; set; }
        public double Unscheduled_Deferment { get; set; }
        public double Thirdparty_Deferment { get; set; }
        public double Crudeoil_Lossess { get; set; }
        public Guid InputDeckId { get; set; }

    }
}
