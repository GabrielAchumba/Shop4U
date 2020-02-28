using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Helpers
{
    public class SupermarketCartUtil
    {
        public SupermarketCartUtil()
        {
            StoreId storeId = new StoreId();
            client = storeId.clientSupermarkets;
        }

        HttpClient client;
        Guid id = Guid.NewGuid();

        public async Task CreateSupermarketCart(SupermarketCart supermarketCart)
        {


            string requestUri = "api/SupermarketCarts";
            var response = await client.PostAsJsonAsync(requestUri, supermarketCart);

            if (response.IsSuccessStatusCode)
                supermarketCart = await response.Content.ReadAsAsync<SupermarketCart>();

        }

        public async Task<SupermarketCart> UpdateSupermarketCart(SupermarketCart supermarketCart, Guid Id)
        {


            string requestUri = $"api/SupermarketCarts/{Id}";
            var response = await client.PutAsJsonAsync(requestUri, supermarketCart);

            if (response.IsSuccessStatusCode)
                supermarketCart = await response.Content.ReadAsAsync<SupermarketCart>();


            return supermarketCart;


        }

        public async Task<IEnumerable<SupermarketCart>> GetSupermarketCarts()
        {


            string requestUri = "api/SupermarketCarts";
            var response = await client.GetAsync(requestUri);
            IEnumerable<SupermarketCart> result = new List<SupermarketCart>();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<IEnumerable<SupermarketCart>>();


            return result;


        }

        public async Task<SupermarketCart> GetSupermarketCart(Guid Id)
        {

            string requestUri = $"api/SupermarketCarts/{Id}";
            var response = await client.GetAsync(requestUri);
            SupermarketCart result = new SupermarketCart();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<SupermarketCart>();


            return result;


        }

        public async Task<SupermarketCart> DeleteSupermarketCart(Guid Id)
        {


            string requestUri = $"api/SupermarketCarts/{Id}";
            var response = await client.DeleteAsync(requestUri);
            SupermarketCart supermarketCart = new SupermarketCart();
            if (response.IsSuccessStatusCode)
                supermarketCart = await response.Content.ReadAsAsync<SupermarketCart>();


            return supermarketCart;


        }

    }
}
