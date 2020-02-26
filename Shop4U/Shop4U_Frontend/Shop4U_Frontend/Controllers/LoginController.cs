using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Shop4U_Frontend.DTOs;
using Shop4U_Frontend.Helpers;
using Shop4U_Frontend.Models;
using Shop4U_Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Controllers
{
    public class LoginController: Controller
    {
        private readonly LoginUtil loginUtil;
        private readonly IFileProvider _fileProvider;
        private readonly IHostingEnvironment _hostingEnvironment;
        public LoginController(IFileProvider fileProvider, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _fileProvider = fileProvider;
            loginUtil = new LoginUtil();
        }


        [HttpGet]
        public ViewResult UserLogin()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginDTO loginDTO)
        {

            if (loginDTO != null)
            {
                loginDTO.ToLogin = true;
                object result= await loginUtil.UserLogin(loginDTO);
                if(result.GetType() == typeof(SuperAdministrator))
                {
                    SuperAdministrator superAdministrator = result as SuperAdministrator;
                    ViewBag.FullName = superAdministrator.FirstName + " " + superAdministrator.LastName;
                    StoreId.ActiveUser_Id = superAdministrator.Id;
                    StoreId.IsLoggedIn = true;
                    StoreId.IsAdminLoggedIn = true;
                    StoreId.IsSuperLoggedIn = true;
                    return RedirectToAction("IndexSuperAdmin", "Home");
                }
                if (result.GetType() == typeof(CustomerVM))
                {
                    CustomerVM customerVM = result as CustomerVM;
                    ViewBag.FullName = customerVM.FirstName + " " + customerVM.LastName;
                    StoreId.ActiveUser_Id = customerVM.Id;
                    StoreId.IsLoggedIn = true;
                    StoreId.IsAdminLoggedIn = false;
                    StoreId.IsSuperLoggedIn = false;
                    return RedirectToAction("Index", "Home");
                }


            }



            return View();
        }

        [HttpGet]
        public ViewResult index()
        {
            return View();
        }

       

       

    }
}
