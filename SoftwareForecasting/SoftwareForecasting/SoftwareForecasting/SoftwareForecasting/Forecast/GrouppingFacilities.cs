using SoftwareForecasting.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareForecasting.Forecast
{
    public class GrouppingFacilities
    {
        
        public static Dictionary<ExtendedFacilityDeck, List<ExtendedInputDeck>> GetFacilitiesByGroup(
            ref List<ExtendedFacilityDeck> ExtendedFacilityDecks,
            ref List<ExtendedInputDeck> ExtendedInputDecks)
        {
            Dictionary<ExtendedFacilityDeck, List<ExtendedInputDeck>> FacilitiesByGroup
                = new Dictionary<ExtendedFacilityDeck, List<ExtendedInputDeck>>();
            foreach (var facility in ExtendedFacilityDecks)
            {
                List<ExtendedInputDeck> decks = new List<ExtendedInputDeck>();
                foreach (var deck in ExtendedInputDecks)
                {
                    if(facility.Primary_Facility.ToLower() == deck.Flow_station.ToLower())
                    {
                        decks.Add(deck);
                    }
                }

                FacilitiesByGroup.Add(facility, decks);
            }

            return FacilitiesByGroup;
        }
    }
}
