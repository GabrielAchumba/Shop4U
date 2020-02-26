using Microsoft.AspNetCore.Http;
using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Helpers
{
    public class ItemsUtil
    {
        public ItemsUtil()
        {
            StoreId storeId = new StoreId();
            client = storeId.clientSupermarkets;
        }

        HttpClient client;
        Guid id = Guid.NewGuid();

        public async Task<IEnumerable<Item>> GetItemsAdmin()
        {


            string requestUri = "api/Items";
            var response = await client.GetAsync(requestUri);
            IEnumerable<Item> result = new List<Item>();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<IEnumerable<Item>>();


            return result;


        }

        public async Task<Item> GetItemAdmin(Guid Id)
        {

            string requestUri = $"api/Items/{Id}";
            var response = await client.GetAsync(requestUri);
            Item result = new Item();

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<Item>();


            return result;


        }

        public async Task CreateItem(Item item)
        {


            string requestUri = "api/Items";
            var response = await client.PostAsJsonAsync(requestUri, item);

            if (response.IsSuccessStatusCode)
                item = await response.Content.ReadAsAsync<Item>();

        }

        public static byte[] ConvertToBytes(IFormFile image)
        {
            byte[] CoverImageBytes = null;
            BinaryReader reader = new BinaryReader(image.OpenReadStream());
            CoverImageBytes = reader.ReadBytes((int)image.Length);
            return CoverImageBytes;
        }

        public static Tuple<double,string> GetItem(string item)
        {
            var chars = item.Split("\t");
            if (chars.Length < 2) return null;
            return new Tuple<double, string>(Convert.ToDouble(chars[2]), chars[1]);
        }
    }
}
