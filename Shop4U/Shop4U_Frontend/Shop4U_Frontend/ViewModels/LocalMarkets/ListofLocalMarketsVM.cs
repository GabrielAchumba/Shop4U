using Shop4U_Frontend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels.LocalMarkets
{
    public class ListofLocalMarketsVM
    {
        public ListofLocalMarketsVM()
        {
            PopulateListofLocalMarkets();
        }

        public List<string> ListofLocalMarkets { get; set; }

        private void PopulateListofLocalMarkets()
        {
            ListofLocalMarkets = StaticModels.LocalMarkets;
        }
    }
}
