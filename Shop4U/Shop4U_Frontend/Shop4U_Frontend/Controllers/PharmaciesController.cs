using Microsoft.AspNetCore.Mvc;
using Shop4U_Frontend.ViewModels.Pharmacies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Controllers
{
    public class PharmaciesController: Controller
    {
        private readonly ListofPharmaciesVM listofPharmaciesVM;
        public PharmaciesController()
        {
            listofPharmaciesVM = new ListofPharmaciesVM();
        }

        [HttpGet]
        public IActionResult ListofPharmacies()
        {

            return View(listofPharmaciesVM);
        }
    }
}
