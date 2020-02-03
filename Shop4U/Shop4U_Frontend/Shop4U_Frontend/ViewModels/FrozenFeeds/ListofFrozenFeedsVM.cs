using Shop4U_Frontend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels.FrozenFeeds
{
    public class ListofFrozenFeedsVM
    {
        public ListofFrozenFeedsVM()
        {
            PopulateListofFrozenFeeds();
        }

        public List<string> ListofFrozenFeeds { get; set; }

        private void PopulateListofFrozenFeeds()
        {
            ListofFrozenFeeds = StaticModels.FrozenFoods;
        }
    }
}
