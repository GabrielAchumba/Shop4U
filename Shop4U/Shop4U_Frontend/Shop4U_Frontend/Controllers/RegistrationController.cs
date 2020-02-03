using Microsoft.AspNetCore.Mvc;
using Shop4U_Frontend.DTOs;
using Shop4U_Frontend.Helpers;
using Shop4U_Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Controllers
{
    public class RegistrationController: Controller
    {
        private RegistrationUtil RegistrationUtil;
        public RegistrationController()
        {
            RegistrationUtil = new RegistrationUtil();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegistrationDTO registrationDTO)
        {

            if (registrationDTO != null)
            {
                CustomerVM customerVM = await RegistrationUtil.CreateCustomer(registrationDTO);
                ViewBag.FullName = customerVM.FirstName + " " + customerVM.LastName;
                StoreId.ActiveUser_Id = customerVM.Id;
                return RedirectToAction("UserLogin", "Login");
            }



            return View();
        }
    }
}
