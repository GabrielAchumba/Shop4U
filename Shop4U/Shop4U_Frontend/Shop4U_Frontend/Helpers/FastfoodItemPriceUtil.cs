using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Helpers
{
    public class FastfoodItemPriceUtil
    {
        public FastfoodItemPriceUtil()
        {
            StoreId storeId = new StoreId();
            client = storeId.clientFastfoods;
        }

        HttpClient client;
        Guid id = Guid.NewGuid();

        public async Task CreateFastfoodItemPrice(FastfoodItemPrice fastfoodItemPrice)
        {


            string requestUri = "api/FastfoodItemPrices";
            var response = await client.PostAsJsonAsync(requestUri, fastfoodItemPrice);

            if (response.IsSuccessStatusCode)
            {
                fastfoodItemPrice = await response.Content.ReadAsAsync<FastfoodItemPrice>();
            }
            else
            {
                fastfoodItemPrice = await UpdateFastfoodItemPrice(fastfoodItemPrice, fastfoodItemPrice.Id);
            }


        }

        public async Task<FastfoodItemPrice> UpdateFastfoodItemPrice(FastfoodItemPrice fastfoodItemPrice, Guid Id)
        {


            string requestUri = $"api/FastfoodItemPrices/{Id}";
            var response = await client.PutAsJsonAsync(requestUri, fastfoodItemPrice);

            if (response.IsSuccessStatusCode)
                fastfoodItemPrice = await response.Content.ReadAsAsync<FastfoodItemPrice>();


            return fastfoodItemPrice;


        }

        public async Task<IEnumerable<FastfoodItemPrice>> GetFastfoodItemPrices()
        {


            string requestUri = "api/FastfoodItemPrices";
            var response = await client.GetAsync(requestUri);
            IEnumerable<FastfoodItemPrice> result = new List<FastfoodItemPrice>();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<IEnumerable<FastfoodItemPrice>>();


            return result;


        }

        public async Task<FastfoodItemPrice> GetFastfoodItemPrice(Guid Id)
        {

            string requestUri = $"api/FastfoodItemPrices/{Id}";
            var response = await client.GetAsync(requestUri);
            FastfoodItemPrice result = new FastfoodItemPrice();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<FastfoodItemPrice>();


            return result;


        }

        public async Task<FastfoodItemPrice> DeleteFastfoodItemPrice(Guid Id)
        {


            string requestUri = $"api/FastfoodItemPrices/{Id}";
            var response = await client.DeleteAsync(requestUri);
            FastfoodItemPrice result = new FastfoodItemPrice();
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<FastfoodItemPrice>();


            return result;


        }
    }
}
