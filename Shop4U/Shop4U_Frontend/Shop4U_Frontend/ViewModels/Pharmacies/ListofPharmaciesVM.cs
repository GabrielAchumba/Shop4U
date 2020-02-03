using Shop4U_Frontend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels.Pharmacies
{
    public class ListofPharmaciesVM
    {
        public ListofPharmaciesVM()
        {
            PopulateListofpharmacy();
        }

        public List<string> Listofpharmacy { get; set; }

        private void PopulateListofpharmacy()
        {
            Listofpharmacy = StaticModels.Pharmacies;
        }
    }
}
