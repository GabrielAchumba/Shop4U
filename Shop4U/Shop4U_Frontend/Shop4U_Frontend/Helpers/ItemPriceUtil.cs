using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Helpers
{
    public class ItemPriceUtil
    {
        public ItemPriceUtil()
        {
            StoreId storeId = new StoreId();
            client = storeId.clientSupermarkets;
        }

        HttpClient client;
        Guid id = Guid.NewGuid();

        public async Task CreateItemPrice(ItemPrice itemPrice)
        {


            string requestUri = "api/ItemPrices";
            var response = await client.PostAsJsonAsync(requestUri, itemPrice);

            if (response.IsSuccessStatusCode)
            {
                itemPrice = await response.Content.ReadAsAsync<ItemPrice>();
            }
            else
            {
                itemPrice = await UpdateItemPrice(itemPrice, itemPrice.Id);
            }
                

        }

        public async Task<ItemPrice> UpdateItemPrice(ItemPrice itemPrice, Guid Id)
        {


            string requestUri = $"api/ItemPrices/{Id}";
            var response = await client.PutAsJsonAsync(requestUri, itemPrice);

            if (response.IsSuccessStatusCode)
                itemPrice = await response.Content.ReadAsAsync<ItemPrice>();


            return itemPrice;


        }

        public async Task<IEnumerable<ItemPrice>> GetItemPricesAdim()
        {


            string requestUri = "api/ItemPrices";
            var response = await client.GetAsync(requestUri);
            IEnumerable<ItemPrice> result = new List<ItemPrice>();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<IEnumerable<ItemPrice>>();


            return result;


        }

        public async Task<ItemPrice> GetItemPriceAdim(Guid Id)
        {

            string requestUri = $"api/ItemPrices/{Id}";
            var response = await client.GetAsync(requestUri);
            ItemPrice result = new ItemPrice();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<ItemPrice>();


            return result;


        }

        public async Task<ItemPrice> DeletItemPrice(Guid Id)
        {


            string requestUri = $"api/ItemPrices/{Id}";
            var response = await client.DeleteAsync(requestUri);
            ItemPrice itemPrice = new ItemPrice();
            if (response.IsSuccessStatusCode)
                itemPrice = await response.Content.ReadAsAsync<ItemPrice>();


            return itemPrice;


        }
    }
}
