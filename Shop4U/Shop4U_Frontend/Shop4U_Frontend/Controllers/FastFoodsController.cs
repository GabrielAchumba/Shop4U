using Microsoft.AspNetCore.Mvc;
using Shop4U_Frontend.ViewModels.FastFoods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Controllers
{
    public class FastFoodsController: Controller
    {
        private readonly ListofFastFoodVM listofFastFoodVM;
        public FastFoodsController()
        {
            listofFastFoodVM = new ListofFastFoodVM();
        }

        [HttpGet]
        public IActionResult ListofFastFood()
        {

            return View(listofFastFoodVM);
        }
    }
}
