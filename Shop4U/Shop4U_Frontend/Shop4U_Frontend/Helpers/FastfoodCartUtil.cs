using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Helpers
{
    public class FastfoodCartUtil
    {
        public FastfoodCartUtil()
        {
            StoreId storeId = new StoreId();
            client = storeId.clientFastfoods;
        }

        HttpClient client;
        Guid id = Guid.NewGuid();

        public async Task CreateFastfoodCart(FastfoodCart fastfoodCart)
        {


            string requestUri = "api/FastfoodCarts";
            var response = await client.PostAsJsonAsync(requestUri, fastfoodCart);

            if (response.IsSuccessStatusCode)
            {
                fastfoodCart = await response.Content.ReadAsAsync<FastfoodCart>();
            }
            else
            {
                fastfoodCart = await UpdateFastfoodCart(fastfoodCart, fastfoodCart.Id);
            }


        }

        public async Task<FastfoodCart> UpdateFastfoodCart(FastfoodCart fastfoodCart, Guid Id)
        {


            string requestUri = $"api/FastfoodCarts/{Id}";
            var response = await client.PutAsJsonAsync(requestUri, fastfoodCart);

            if (response.IsSuccessStatusCode)
                fastfoodCart = await response.Content.ReadAsAsync<FastfoodCart>();


            return fastfoodCart;


        }

        public async Task<IEnumerable<FastfoodCart>> GetFastfoodCarts()
        {


            string requestUri = "api/FastfoodCarts";
            var response = await client.GetAsync(requestUri);
            IEnumerable<FastfoodCart> result = new List<FastfoodCart>();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<IEnumerable<FastfoodCart>>();


            return result;


        }

        public async Task<FastfoodCart> GetFastfoodCart(Guid Id)
        {

            string requestUri = $"api/FastfoodCarts/{Id}";
            var response = await client.GetAsync(requestUri);
            FastfoodCart result = new FastfoodCart();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<FastfoodCart>();


            return result;


        }

        public async Task<FastfoodCart> DeleteFastfoodCart(Guid Id)
        {


            string requestUri = $"api/FastfoodCarts/{Id}";
            var response = await client.DeleteAsync(requestUri);
            FastfoodCart result = new FastfoodCart();
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<FastfoodCart>();


            return result;


        }
    }
}
