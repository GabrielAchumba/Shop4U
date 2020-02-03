using Shop4U_Frontend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels.Supermarkets
{
    public class ListofSupermarketsVM
    {
        public ListofSupermarketsVM()
        {
            PopulateSupermarkets();
        }

        public List<string> Supermarkets { get; set; }

        private void PopulateSupermarkets()
        {
            Supermarkets = StaticModels.Supermarkets;
        }
    }
}
