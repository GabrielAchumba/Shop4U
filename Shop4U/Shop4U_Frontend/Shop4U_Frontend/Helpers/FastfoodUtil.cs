using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Helpers
{
    public class FastfoodUtil
    {
        public FastfoodUtil()
        {
            StoreId storeId = new StoreId();
            client = storeId.clientFastfoods;
        }

        HttpClient client;
        Guid id = Guid.NewGuid();

        public async Task CreateFastfood(Fastfood fastfood)
        {


            string requestUri = "api/Fastfoods";
            var response = await client.PostAsJsonAsync(requestUri, fastfood);

            if (response.IsSuccessStatusCode)
            {
                fastfood = await response.Content.ReadAsAsync<Fastfood>();
            }
            else
            {
                fastfood = await UpdateFastfood(fastfood, fastfood.Id);
            }


        }

        public async Task<Fastfood> UpdateFastfood(Fastfood fastfood, Guid Id)
        {


            string requestUri = $"api/Fastfoods/{Id}";
            var response = await client.PutAsJsonAsync(requestUri, fastfood);

            if (response.IsSuccessStatusCode)
                fastfood = await response.Content.ReadAsAsync<Fastfood>();


            return fastfood;


        }

        public async Task<IEnumerable<Fastfood>> GetFastfoods()
        {


            string requestUri = "api/Fastfoods";
            var response = await client.GetAsync(requestUri);
            IEnumerable<Fastfood> result = new List<Fastfood>();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<IEnumerable<Fastfood>>();


            return result;


        }

        public async Task<Fastfood> GetFastfood(Guid Id)
        {

            string requestUri = $"api/Fastfoods/{Id}";
            var response = await client.GetAsync(requestUri);
            Fastfood result = new Fastfood();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<Fastfood>();


            return result;


        }

        public async Task<Fastfood> DeleteFastfood(Guid Id)
        {


            string requestUri = $"api/Fastfoods/{Id}";
            var response = await client.DeleteAsync(requestUri);
            Fastfood fastfood = new Fastfood();
            if (response.IsSuccessStatusCode)
                fastfood = await response.Content.ReadAsAsync<Fastfood>();


            return fastfood;


        }
    }
}
