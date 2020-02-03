using Shop4U_Frontend.DTOs;
using Shop4U_Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Helpers
{
    public class LoginUtil
    {
        public LoginUtil()
        {

            baseUrl = "https://localhost:44374/";
            client = new HttpClient();
            client.BaseAddress = new System.Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        HttpClient client;
        Guid id = Guid.NewGuid();
        string baseUrl;
        SuperAdministrator SuperAdministrator;
        CustomerVM CustomerVM;

        public async Task<object> UserLogin(LoginDTO loginDTO)
        {
            bool isLogin = true;
             SuperAdministrator = new SuperAdministrator();
            string requestUri = $"api/superadministrators/LoginSuperAdministrator/{isLogin}";
            var response = await client.PostAsJsonAsync(requestUri, loginDTO);

            if (response.IsSuccessStatusCode)
            {
                SuperAdministrator = await response.Content.ReadAsAsync<SuperAdministrator>();
                if (SuperAdministrator.UserType == "SuperAdmin")
                {
                    return SuperAdministrator;
                }
                    
            }
                

            if(SuperAdministrator.UserType == "")
            {
                CustomerVM = new CustomerVM();
                requestUri = $"api/customers/LoginCustomer/{isLogin}";

                var CustomerResponse = await client.PostAsJsonAsync(requestUri, loginDTO);

                if (CustomerResponse.IsSuccessStatusCode)
                    CustomerVM = await CustomerResponse.Content.ReadAsAsync<CustomerVM>();
                if (CustomerVM.UserType == "User")
                {
                    return CustomerVM;
                }
                
            }

            return null;


        }
    }

    public class SuperAdministrator
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
