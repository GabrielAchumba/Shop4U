using Microsoft.AspNetCore.Mvc;
using Shop4U_Frontend.ViewModels.CookingGas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Controllers
{
    public class CookingGasController: Controller
    {
        private readonly ListofCookingGasVM listofCookingGasVM;
        public CookingGasController()
        {
            listofCookingGasVM = new ListofCookingGasVM();
        }

        [HttpGet]
        public IActionResult ListofCookingGas()
        {

            return View(listofCookingGasVM);
        }
    }
}
