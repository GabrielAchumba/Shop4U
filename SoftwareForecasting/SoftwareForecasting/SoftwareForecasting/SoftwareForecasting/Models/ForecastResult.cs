using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareForecasting.Models
{
    public class ForecastResult
    {
        public ForecastResult()
        {
            id = Guid.NewGuid();
        }
        public Guid id { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double Oil_rate { get; set; }
        public double Gas_Rate { get; set; }
        public double Water_Rate { get; set; }
        public double GOR { get; set; }
        public double CGR { get; set; }
        public double BSW { get; set; }
        public double WGR { get; set; }
        public double Cum_Oil_Prod { get; set; }
        public double Cum_Gas_Prod { get; set; }
        public double Cum_Water_Prod { get; set; }
        public string Description { get; set; }
        public double Decision_Variable { get; set; }
        public double Gas_Own_Use { get; set; }
        public double Gas_Demand { get; set; }
        public double Crude_Oil_Lossess { get; set; }
        public Guid InputDeckId { get; set; }
    }
}
