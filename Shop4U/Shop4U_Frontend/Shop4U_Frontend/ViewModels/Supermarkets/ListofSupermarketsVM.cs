using Shop4U_Frontend.Helpers;
using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels.Supermarkets
{
    public class ListofSupermarketsVM
    {
        public ListofSupermarketsVM(IEnumerable<Supermarket> _Supermarkets)
        {
            PageTitle = "Shop4u | supermarkets";
            GetSupermarkets(_Supermarkets);
        }

        public List<Supermarket> Supermarkets { get; set; }
        public string PageTitle { get; set; }

        private void GetSupermarkets(IEnumerable<Supermarket> _Supermarkets)
        {
            Supermarkets = _Supermarkets.ToList();
        }
    }
}
