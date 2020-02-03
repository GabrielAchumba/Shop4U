using Microsoft.AspNetCore.Mvc;
using Shop4U_Frontend.ViewModels.PoultryFarms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Controllers
{
    public class PoultryFarmsController: Controller
    {
        private readonly ListofpoultryVM listofpoultryVM;

        public PoultryFarmsController()
        {
            listofpoultryVM = new ListofpoultryVM();
        }

        [HttpGet]
        public IActionResult Listofpoultry()
        {

            return View(listofpoultryVM);
        }
    }
}
