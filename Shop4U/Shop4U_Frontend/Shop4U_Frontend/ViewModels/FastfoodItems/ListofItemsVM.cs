using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels.FastfoodItems
{
    public class ListofItemsVM
    {
        public ListofItemsVM()
        {
            ShowNumberList = new List<string>();
            Items = new List<FastfoodItem>();
        }

        public int ShowNumber { get; set; }
        public List<string> ShowNumberList { get; set; }
        public List<FastfoodItem> Items { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public void GetItems(IEnumerable<FastfoodItem> items)
        {
            if(items.Count() > 0)
            {
                this.Items = items.ToList();

                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].BackgrounndPicture != null)
                        Items[i].Base64String = "data:image/png;base64," + Convert.ToBase64String(Items[i].BackgrounndPicture, 0, Items[i].BackgrounndPicture.Length);
                    
                }
            }
                
        }
    }
}
