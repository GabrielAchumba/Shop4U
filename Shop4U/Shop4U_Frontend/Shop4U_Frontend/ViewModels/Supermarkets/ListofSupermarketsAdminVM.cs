using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels.Supermarkets
{
    public class ListofSupermarketsAdminVM
    {
        public ListofSupermarketsAdminVM(IEnumerable<Supermarket> Supermarkets)
        {
            PageTitle = "Shop4u | supermarkets";
            GetSupermarkets(Supermarkets.ToList());
        }

        public string PageTitle { get; set; }
        public List<Supermarket> Supermarkets { get; set; }

        private void GetSupermarkets(List<Supermarket> _Supermarkets)
        {
            Supermarkets = new List<Supermarket>();
            foreach (var item in _Supermarkets)
            {
                if(item.BackgrounndPicture != null)
                item.Base64String = "data:image/png;base64," + Convert.ToBase64String(item.BackgrounndPicture, 0, item.BackgrounndPicture.Length);
                Supermarkets.Add(item);
            }
            
        }
    }
}
