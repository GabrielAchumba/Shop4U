using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareForecasting.Forecast
{
    public class Decline_Curve_Analysis
    {

        public static double Get_DCA(double Initial_Rate, double Rate_Of_Change, double Cum_Prod, string Method)
        {
            double rate = 0;
            switch (Method)
            {
                case "exponential":
                    rate = Get_DCA_Exponential(Initial_Rate, Rate_Of_Change, Cum_Prod);
                    break;

                case "harmonic":
                    break;

                case "hyperbolic":
                    break;
            }
            double Current_Rate = Initial_Rate - Rate_Of_Change * Cum_Prod;

            return Current_Rate;
        }
        private static double Get_DCA_Exponential(double Initial_Rate, double Rate_Of_Change, double Cum_Prod)
        {
            double Current_Rate = Initial_Rate - Rate_Of_Change * Cum_Prod;

            return Current_Rate;
        }

        public static double Get_DeclineFactor_Exponential(double Initial_Rate,double Aband_Rate, double Init_Cum_Prod,
            double UR)
        {
            double DeclineFactor = (Initial_Rate - Aband_Rate) /(UR - Init_Cum_Prod);

            return DeclineFactor;
        }
    }
}
