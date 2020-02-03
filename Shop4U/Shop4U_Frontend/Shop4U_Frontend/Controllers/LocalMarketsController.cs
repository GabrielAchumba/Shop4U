using Microsoft.AspNetCore.Mvc;
using Shop4U_Frontend.ViewModels.LocalMarkets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Controllers
{
    public class LocalMarketsController: Controller
    {
        private readonly ListofLocalMarketsVM listofLocalMarketsVM;
        public LocalMarketsController()
        {
            listofLocalMarketsVM = new ListofLocalMarketsVM();
        }

        [HttpGet]
        public IActionResult ListofLocalMarkets()
        {

            return View(listofLocalMarketsVM);
        }
    }
}
