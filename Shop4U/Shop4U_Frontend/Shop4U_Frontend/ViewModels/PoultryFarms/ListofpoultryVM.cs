using Shop4U_Frontend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels.PoultryFarms
{
    public class ListofpoultryVM
    {
        public ListofpoultryVM()
        {
            PopulateListofpoultry();
        }

        public List<string> Listofpoultry { get; set; }

        private void PopulateListofpoultry()
        {
            Listofpoultry = StaticModels.PoutryFarms;
        }
    }
}
