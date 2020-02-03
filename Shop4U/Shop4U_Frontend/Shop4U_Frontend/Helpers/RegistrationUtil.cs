using Shop4U_Frontend.DTOs;
using Shop4U_Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Helpers
{
    public class RegistrationUtil
    {
        public RegistrationUtil()
        {
            StoreId storeId = new StoreId();
            client = storeId.clientEnrollment;
           
        }

        HttpClient client;
        Guid id = Guid.NewGuid();
        string controllerName = "customers";
        CustomerVM customerVM;

        public async Task<CustomerVM> CreateCustomer(RegistrationDTO registrationDTO)
        {

            customerVM = new CustomerVM();
            string requestUri = "api/customers/PostCustomer";
            var response = await client.PostAsJsonAsync(requestUri, registrationDTO);

            if (response.IsSuccessStatusCode)
                customerVM = await response.Content.ReadAsAsync<CustomerVM>();


            return customerVM;


        }
    }

    
}
