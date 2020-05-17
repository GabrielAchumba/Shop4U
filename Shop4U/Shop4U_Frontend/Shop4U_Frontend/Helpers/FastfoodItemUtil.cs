using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Helpers
{
    public class FastfoodItemUtil
    {
        public FastfoodItemUtil()
        {
            StoreId storeId = new StoreId();
            client = storeId.clientFastfoods;
        }

        HttpClient client;
        Guid id = Guid.NewGuid();

        public async Task CreateFastfoodItem(FastfoodItem fastfoodItem)
        {


            string requestUri = "api/FastfoodItems";
            var response = await client.PostAsJsonAsync(requestUri, fastfoodItem);

            if (response.IsSuccessStatusCode)
            {
                fastfoodItem = await response.Content.ReadAsAsync<FastfoodItem>();
            }
            else
            {
                fastfoodItem = await UpdateFastfoodItem(fastfoodItem, fastfoodItem.Id);
            }


        }

        public async Task<FastfoodItem> UpdateFastfoodItem(FastfoodItem fastfoodItem, Guid Id)
        {


            string requestUri = $"api/FastfoodItems/{Id}";
            var response = await client.PutAsJsonAsync(requestUri, fastfoodItem);

            if (response.IsSuccessStatusCode)
                fastfoodItem = await response.Content.ReadAsAsync<FastfoodItem>();


            return fastfoodItem;


        }

        public async Task<IEnumerable<FastfoodItem>> GetFastfoodItems()
        {


            string requestUri = "api/FastfoodItems";
            var response = await client.GetAsync(requestUri);
            IEnumerable<FastfoodItem> result = new List<FastfoodItem>();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<IEnumerable<FastfoodItem>>();


            return result;


        }

        public async Task<FastfoodItem> GetFastfoodItem(Guid Id)
        {

            string requestUri = $"api/FastfoodItems/{Id}";
            var response = await client.GetAsync(requestUri);
            FastfoodItem result = new FastfoodItem();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<FastfoodItem>();


            return result;


        }

        public async Task<FastfoodItem> DeleteFastfoodItem(Guid Id)
        {


            string requestUri = $"api/FastfoodItems/{Id}";
            var response = await client.DeleteAsync(requestUri);
            FastfoodItem result = new FastfoodItem();
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<FastfoodItem>();


            return result;


        }
    }
}
