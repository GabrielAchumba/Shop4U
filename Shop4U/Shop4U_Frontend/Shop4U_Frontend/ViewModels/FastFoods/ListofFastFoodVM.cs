using Shop4U_Frontend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels.FastFoods
{
    public class ListofFastFoodVM
    {
        public ListofFastFoodVM()
        {
            PopulateListoffastfood();
        }

        public List<string> Listoffastfood { get; set; }

        private void PopulateListoffastfood()
        {
            Listoffastfood = StaticModels.FastFoods;
        }
    }
}
