using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareForecasting.Forecast
{
    public class FractionalFlow
    {
        public static double Get_Fractional_Rate_Of_Change_Exponential(double X_init, double X_last, double Y_init, double Y_last)
        {
            double numerator = (Y_last / Y_init);

            double denominator = X_last - X_init;

            double Fractional_Rate_Of_Change = Math.Log(numerator, Math.E) / denominator;

            return Fractional_Rate_Of_Change;
        }

        public static double Get_Fractional_Flow(double Fractional_Rate_Of_Change, double X_init, double X_last, double Y_init)
        {
            double Y = Y_init * Math.Exp(Fractional_Rate_Of_Change * (X_last - X_init));

            return Y;
        }
    }
}
