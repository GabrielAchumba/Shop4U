using Microsoft.AspNetCore.Mvc;
using Shop4U_Frontend.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Controllers
{

    public class HomeController: Controller
    {
        private readonly HomeIndexViewModel homeIndexViewModel;
        private readonly HomeAboutViewModel homeAboutViewModel;
        public HomeController()
        {
            homeIndexViewModel = new HomeIndexViewModel();
            homeAboutViewModel = new HomeAboutViewModel();
        }

        [HttpGet]
        public IActionResult IndexSuperAdmin()
        {
           
            return View(homeIndexViewModel);
        }

        [HttpGet]
        public IActionResult IndexAdmin()
        {

            return View(homeIndexViewModel);
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View(homeIndexViewModel);
        }

        [HttpGet]
        public IActionResult About()
        {

            return View(homeAboutViewModel);
        }
    }
}
