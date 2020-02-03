using Shop4U_Frontend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels
{
    public class UserLoginVM
    {
        public UserLoginVM()
        {
            errorMessage = "";
        }
        public string errorMessage { get; set; }
        public LoginDTO LoginDTO { get; set; }
    }
}
