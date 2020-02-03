using Shop4U_Frontend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels.CookingGas
{
    public class ListofCookingGasVM
    {
        public ListofCookingGasVM()
        {
            PopulateListofcookinggas();
        }

        public List<string> Listofcookinggas { get; set; }

        private void PopulateListofcookinggas()
        {
            Listofcookinggas = StaticModels.CookingGas;
        }
    }
}
