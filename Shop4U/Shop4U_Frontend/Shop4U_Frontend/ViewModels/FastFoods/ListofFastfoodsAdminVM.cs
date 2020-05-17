using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels
{
    public class ListofFastfoodsAdminVM
    {
        public ListofFastfoodsAdminVM(IEnumerable<Fastfood> Fastfoods)
        {
            PageTitle = "Shop4u | fastfoods";
            GetFastfoods(Fastfoods.ToList());
        }

        public string PageTitle { get; set; }
        public List<Fastfood> Fastfoods { get; set; }

        private void GetFastfoods(List<Fastfood> _Fastfoods)
        {
            Fastfoods = new List<Fastfood>();
            foreach (var item in _Fastfoods)
            {
                if(item.BackgrounndPicture != null)
                item.Base64String = "data:image/png;base64," + Convert.ToBase64String(item.BackgrounndPicture, 0, item.BackgrounndPicture.Length);
                Fastfoods.Add(item);
            }
            
        }
    }
}
