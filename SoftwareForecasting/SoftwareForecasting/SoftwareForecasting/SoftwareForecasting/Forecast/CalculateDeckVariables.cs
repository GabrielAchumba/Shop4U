using SoftwareForecasting.Mathematics;
using SoftwareForecasting.Models;
using SoftwareForecasting.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareForecasting.Forecast
{
    public class CalculateDeckVariables
    {
        private static double DeltaT = 0;
        public async static Task GetDeckVariables(Dictionary<ExtendedFacilityDeck, List<ExtendedInputDeck>> Facilities,
              List<DateTime> dates, int scenario)
        {
            
           
            foreach (var facility in Facilities)
            {
                GetDeckVariables(facility,  ref scenario, ref dates);
            }
        }

        private static void GetDeckVariables( KeyValuePair<ExtendedFacilityDeck, List<ExtendedInputDeck>> facility,
            ref int scenario, ref List<DateTime> dates)
        {

            for (int i = 0; i < dates.Count; i++)
            {
                if (i == 0) DeltaT = 0;
                else DeltaT = (dates[i] - dates[i - 1]).TotalDays;

                foreach (var deck in facility.Value)
                {
                    ForecastResult forecastResult = new ForecastResult();

                    GetActiveRate(ref scenario, deck, ref forecastResult);

                    GetVariables(ref scenario, deck, ref forecastResult);

                    //optimize(ref scenario, deck);

                }
            }
            
        }

        private static void optimize(ref int scenario, ExtendedInputDeck deck, ref ForecastResult forecastResult)
        {

            GetVariables(ref scenario, deck, ref forecastResult);
        }
        private static void GetVariables(ref int scenario, ExtendedInputDeck deck, ref ForecastResult forecastResult)
        {
            

            GetActiveCumProd(ref scenario, deck, ref forecastResult); // To be worked on

            GetGasFractionalFlow(ref scenario, deck, ref forecastResult);

            GetWaterFractionalFlow(ref scenario, deck, ref forecastResult);

            GetRates(ref scenario, deck, ref forecastResult);

            GetCumProds(ref scenario, deck, ref forecastResult); // To be worked on
        }

        private static void GetActiveRate(ref int scenario,  ExtendedInputDeck deck, ref ForecastResult forecastResult)
        {
            string method = "exponential";
            double cumprod = 0;

            if (deck.Hydrocarbon_Stream.ToLower() == "oil") cumprod = deck.Np;
            else cumprod = deck.Gp;

            switch (scenario)
            {
                case 1:
                    forecastResult.Oil_rate = Decline_Curve_Analysis.Get_DCA(deck.Init_Oil_Gas_Rate_1P_1C,
                    deck.Rate_of_Change_Rate_1P_1C, cumprod, method);

                    break;

                case 2:
                    forecastResult.Oil_rate = Decline_Curve_Analysis.Get_DCA(deck.Init_Oil_Gas_Rate_2P_2C,
                    deck.Rate_of_Change_Rate_2P_2C, cumprod, method);

                    break;

                case 3:
                    forecastResult.Oil_rate = Decline_Curve_Analysis.Get_DCA(deck.Init_Oil_Gas_Rate_3P_3C,
                    deck.Rate_of_Change_Rate_3P_3C, cumprod, method);
                    break;
            }
        }

        private static void GetActiveCumProd(ref int scenario, ExtendedInputDeck deck, ref ForecastResult forecastResult)
        {


            if (deck.Hydrocarbon_Stream.ToLower() == "oil")
            {
                switch (scenario)
                {
                    case 1:
                        forecastResult.Cum_Oil_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Oil_rate);
                        break;

                    case 2:
                        forecastResult.Cum_Oil_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Oil_rate);
                        break;

                    case 3:
                        forecastResult.Cum_Oil_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Oil_rate);
                        break;
                }
            }
            else
            {
                switch (scenario)
                {
                    case 1:
                        forecastResult.Cum_Gas_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Oil_rate);
                        break;

                    case 2:
                        forecastResult.Cum_Gas_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Oil_rate);
                        break;

                    case 3:
                        forecastResult.Cum_Gas_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Oil_rate);
                        break;
                }
            }
                

        }

        private static void GetGasFractionalFlow(ref int scenario, ExtendedInputDeck deck, ref ForecastResult forecastResult)
        {
            
            if(deck.Hydrocarbon_Stream.ToLower() == "oil")
            {
                switch (scenario)
                {
                    case 1:
                        forecastResult.GOR = FractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_GOR_CGR_1P1C, forecastResult.Cum_Oil_Prod,
                            deck.URo_1P_1C, deck.Init_GOR_CGR);
                        break;

                    case 2:
                        forecastResult.GOR = FractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_GOR_CGR_2P2C, forecastResult.Cum_Oil_Prod,
                            deck.URo_2P_2C, deck.Init_GOR_CGR);
                        break;

                    case 3:
                        forecastResult.GOR = FractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_GOR_CGR_3P3C, forecastResult.Cum_Oil_Prod,
                            deck.URo_3P_3C, deck.Init_GOR_CGR);
                        break;
                }
            }
            else
            {
                switch (scenario)
                {
                    case 1:
                        forecastResult.CGR = FractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_GOR_CGR_1P1C, forecastResult.Cum_Gas_Prod,
                            deck.URg_1P_1C, deck.Init_GOR_CGR);
                        break;

                    case 2:
                        forecastResult.CGR = FractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_GOR_CGR_2P2C, forecastResult.Cum_Gas_Prod,
                            deck.URg_2P_2C, deck.Init_GOR_CGR);
                        break;

                    case 3:
                        forecastResult.CGR = FractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_GOR_CGR_3P3C, forecastResult.Cum_Gas_Prod,
                            deck.URg_3P_3C, deck.Init_GOR_CGR);
                        break;
                }
            }
            
        }

        private static void GetWaterFractionalFlow(ref int scenario, ExtendedInputDeck deck, ref ForecastResult forecastResult)
        {

            if (deck.Hydrocarbon_Stream.ToLower() == "oil")
            {
                switch (scenario)
                {
                    case 1:
                        forecastResult.BSW = FractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_BSW_WGR_1P1C, forecastResult.Cum_Oil_Prod,
                            deck.URo_1P_1C, deck.Init_BSW_WGR);
                        break;

                    case 2:
                        forecastResult.BSW = FractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_BSW_WGR_2P2C, forecastResult.Cum_Oil_Prod,
                            deck.URo_2P_2C, deck.Init_BSW_WGR);
                        break;

                    case 3:
                        forecastResult.BSW = FractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_BSW_WGR_3P3C, forecastResult.Cum_Oil_Prod,
                            deck.URo_3P_3C, deck.Init_BSW_WGR);
                        break;
                }
            }
            else
            {
                switch (scenario)
                {
                    case 1:
                        forecastResult.WGR = FractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_BSW_WGR_1P1C, forecastResult.Cum_Gas_Prod,
                            deck.URg_1P_1C, deck.Init_BSW_WGR);
                        break;

                    case 2:
                        forecastResult.WGR = FractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_BSW_WGR_2P2C, forecastResult.Cum_Gas_Prod,
                            deck.URg_2P_2C, deck.Init_BSW_WGR);
                        break;

                    case 3:
                        forecastResult.WGR = FractionalFlow.Get_Fractional_Flow(deck.Rate_Of_Rate_BSW_WGR_3P3C, forecastResult.Cum_Gas_Prod,
                            deck.URg_3P_3C, deck.Init_BSW_WGR);
                        break;
                }
            }

        }

        private static void GetRates(ref int scenario, ExtendedInputDeck deck, ref ForecastResult forecastResult)
        {
            if(deck.Hydrocarbon_Stream.ToLower() == "oil")
            {
                forecastResult.Gas_Rate = forecastResult.Oil_rate * forecastResult.GOR;
                forecastResult.Water_Rate = forecastResult.Oil_rate * forecastResult.BSW /
                    (1 - forecastResult.BSW);
            }
            else
            {
                forecastResult.Oil_rate = forecastResult.Gas_Rate * forecastResult.CGR;
                forecastResult.Water_Rate = forecastResult.Gas_Rate * forecastResult.WGR;
            }
        }

        private static void GetCumProds(ref int scenario, ExtendedInputDeck deck, ref ForecastResult forecastResult)
        {

            if (deck.Hydrocarbon_Stream.ToLower() == "oil")
            {
                switch (scenario)
                {
                    case 1:
                        forecastResult.Cum_Gas_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Gas_Rate);
                        forecastResult.Cum_Water_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Water_Rate);
                        break;

                    case 2:
                        forecastResult.Cum_Gas_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Gas_Rate);
                        forecastResult.Cum_Water_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Water_Rate);
                        break;

                    case 3:
                        forecastResult.Cum_Gas_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Gas_Rate);
                        forecastResult.Cum_Water_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Water_Rate);
                        break;
                }
            }
            else
            {
                switch (scenario)
                {
                    case 1:
                        forecastResult.Cum_Oil_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Oil_rate);
                        forecastResult.Cum_Water_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Water_Rate);
                        break;

                    case 2:
                        forecastResult.Cum_Oil_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Oil_rate);
                        forecastResult.Cum_Water_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Water_Rate);
                        break;

                    case 3:
                        forecastResult.Cum_Oil_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Oil_rate);
                        forecastResult.Cum_Water_Prod = Integration.Trapezoidal(DeltaT, forecastResult.Water_Rate);
                        break;
                }
            }

               

           
        }
    }
}
