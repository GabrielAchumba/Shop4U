using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels
{
    public class AddToCartVM
    {
        public AddToCartVM()
        {
            Supermarketcarts = new List<SupermarketCart>();
        }

        public List<SupermarketCart> Supermarketcarts { get; set; }
        public string TotalAmount { get; set; }

        public void CreateSupermarketcarts(SupermarketCart supermarketCart,List<SupermarketCart> supermarketcarts)
        {
            if (supermarketcarts.Count <= 0) return;

            Supermarketcarts = new List<SupermarketCart>();
            double sum = 0;
            for (int i = 0; i < supermarketcarts.Count; i++)
            {
                if(supermarketCart.CustomerId == supermarketcarts[i].CustomerId
                    && supermarketCart.Day == supermarketcarts[i].Day
                    && supermarketCart.Month == supermarketcarts[i].Month
                    && supermarketCart.Year == supermarketcarts[i].Year
                   && supermarketcarts[i].IsPaid == false)
                {
                    sum = sum + Convert.ToDouble(supermarketcarts[i].CostPrice);
                    Supermarketcarts.Add(supermarketcarts[i]);
                }
            }

            TotalAmount = Convert.ToString(sum);
        }
    }
}
