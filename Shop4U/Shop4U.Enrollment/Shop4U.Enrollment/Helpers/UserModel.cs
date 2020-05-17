using Shop4U.Enrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Helpers
{
    public class UserModel
    {
        public UserModel()
        {
            Succeeded = false;
        }
        public bool Succeeded { get; set; }
        void CreateCustomer(Customer user, List<Customer> users)
        {

            foreach (var item in users)
            {
                if(item == user)
                {
                    Succeeded = true;
                    break;
                }
            }
        }

        void FindByPhoneNumber(string phoneNumber, List<T> users)
        {
            foreach (var item in users)
            {
                if (item.phoneNumber == phoneNumber)
                {
                    Succeeded = true;
                    break;
                }
            }
        }
    }
}
