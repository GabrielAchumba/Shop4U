using Shop4U_Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Helpers
{
    public class StoreId
    {
        public StoreId()
        {
            clientEnrollment = new HttpClient();
            clientEnrollment.BaseAddress = new System.Uri(baseUrlEnrollment);
            clientEnrollment.DefaultRequestHeaders.Clear();
            clientEnrollment.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            clientSupermarkets = new HttpClient();
            clientSupermarkets.BaseAddress = new System.Uri(baseUrlSupermarkets);
            clientSupermarkets.DefaultRequestHeaders.Clear();
            clientSupermarkets.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static bool IsLoggedIn { get; set; }
        public static bool IsAdminLoggedIn { get; set; }
        public static bool IsSuperLoggedIn { get; set; }
        public static Guid ActiveUser_Id { get; set; }

        public static CreateItemsVM createItemsVM;

        public static Guid ActiveSupermarket_Id { get; set; }
        public static Guid ActiveItem_Id { get; set; }

        public static  string baseUrlEnrollment = "https://localhost:44374/";
        public static string baseUrlSupermarkets = "https://localhost:44301/";

        
        public   HttpClient clientEnrollment { get; set; }
        public HttpClient clientSupermarkets { get; set; }
    }

    public class ObjectClass
    {
        public string MarketName { get; set; }
        public string MarketGroup { get; set; }
        public Guid ItemId { get; set; }
    }
}
