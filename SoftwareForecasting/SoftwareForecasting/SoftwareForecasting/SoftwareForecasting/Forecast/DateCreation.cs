using SoftwareForecasting.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareForecasting.Forecast
{
    public class DateCreation
    {
        public static List<DateTime> GetDateList(List<ExtendedInputDeck> decks, DateTime StopDate, string TimeFrequency = "monthly")
        {
            List<DateTime> dateTimes = new List<DateTime>();

            foreach (var deck in decks)
            {
                dateTimes.Add(deck.On_Stream_Date_1P_1C);
                dateTimes.Add(deck.On_Stream_Date_2P_2C);
                dateTimes.Add(deck.On_Stream_Date_3P_3C);
            }

            DateTime StartDate = dateTimes.Min();

            switch (TimeFrequency)
            {
                case "monthly":
                    for (DateTime date = StartDate; date <= StopDate; date.AddMonths(1))
                    {
                        if(!dateTimes.Contains(date))
                            dateTimes.Add(date);
                    }
                    break;

                case "yearly":
                    for (DateTime date = StartDate; date <= StopDate; date.AddYears(1))
                    {
                        dateTimes.Add(date);
                    }
                    break;
            }

            return dateTimes;


        }


    }
}
