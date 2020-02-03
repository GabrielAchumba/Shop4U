using Shop4U_Frontend.Models;
using Shop4U_Frontend.ViewModels.Supermarkets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Helpers
{
    public class SupermarketsUtil
    {
        public SupermarketsUtil()
        {
            StoreId storeId = new StoreId();
            client = storeId.clientSupermarkets;

        }

        HttpClient client;
        Guid id = Guid.NewGuid();


        public async Task<IEnumerable<Supermarket>> GetSupermarketsAdim()
        {


            string requestUri = "api/supermarkets";
            var response = await client.GetAsync(requestUri);
            IEnumerable<Supermarket> result = new List<Supermarket>();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<IEnumerable<Supermarket>>();


            return result;


        }

        public async Task<Supermarket> GetSupermarketAdmin(Guid Id)
        {

            string requestUri = $"api/supermarkets/{Id}";
            var response = await client.GetAsync(requestUri);
            Supermarket result = new Supermarket();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<Supermarket>();


            return result;


        }


        public async Task<Supermarket> CreateSupermarket(Supermarket supermarket)
        {

            
            string requestUri = "api/supermarkets";
            var response = await client.PostAsJsonAsync(requestUri, supermarket);

            if (response.IsSuccessStatusCode)
                supermarket = await response.Content.ReadAsAsync<Supermarket>();


            return supermarket;


        }

        public async Task<Supermarket> UpdateSupermarket(Supermarket supermarket,Guid Id)
        {


            string requestUri = $"api/supermarkets/{Id}"; 
            var response = await client.PutAsJsonAsync(requestUri, supermarket);

            if (response.IsSuccessStatusCode)
                supermarket = await response.Content.ReadAsAsync<Supermarket>();


            return supermarket;


        }

        public async Task<Supermarket> DeletSupermarket(Guid Id)
        {


            string requestUri = $"api/supermarkets/{Id}";
            var response = await client.DeleteAsync(requestUri);
            Supermarket supermarket = new Supermarket();
            if (response.IsSuccessStatusCode)
                supermarket = await response.Content.ReadAsAsync<Supermarket>();


            return supermarket;


        }
    }
}
