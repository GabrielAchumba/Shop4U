using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels
{
    public class AddToFastfoodCartVM
    {
        public AddToFastfoodCartVM()
        {
            Fastfoodcarts = new List<FastfoodCart>();
        }

        public List<FastfoodCart> Fastfoodcarts { get; set; }
        public string TotalAmount { get; set; }

        public void CreateFastfoodcarts(FastfoodCart fastfoodCart, List<FastfoodCart> fastfoodcarts)
        {
            if (fastfoodcarts.Count <= 0) return;

            Fastfoodcarts = new List<FastfoodCart>();
            double sum = 0;
            for (int i = 0; i < fastfoodcarts.Count; i++)
            {
                if(fastfoodCart.CustomerId == fastfoodcarts[i].CustomerId
                    && fastfoodCart.Day == fastfoodcarts[i].Day
                    && fastfoodCart.Month == fastfoodcarts[i].Month
                    && fastfoodCart.Year == fastfoodcarts[i].Year
                   && fastfoodcarts[i].IsPaid == false)
                {
                    if(string.IsNullOrEmpty(fastfoodcarts[i].CostPrice) == false)
                    {
                        sum = sum + Convert.ToDouble(fastfoodcarts[i].CostPrice);
                        Fastfoodcarts.Add(fastfoodcarts[i]);
                    }
                    
                }
            }

            TotalAmount = Convert.ToString(sum);
        }
    }
}
