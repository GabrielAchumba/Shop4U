using Shop4U_Frontend.Helpers;
using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels
{
    public class ListofFastfoodsVM
    {
        public ListofFastfoodsVM(IEnumerable<Fastfood> _Fastfoods)
        {
            PageTitle = "Shop4u | fastfoods";
            GetFastfoods(_Fastfoods);
        }

        public List<Fastfood> Fastfoods { get; set; }
        public string PageTitle { get; set; }

        private void GetFastfoods(IEnumerable<Fastfood> _Fastfoods)
        {
            Fastfoods = _Fastfoods.ToList();
        }
    }
}
