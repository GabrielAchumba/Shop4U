using Microsoft.AspNetCore.Mvc;
using Shop4U_Frontend.ViewModels.FrozenFeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.Controllers
{
    public class FrozenFeedsController: Controller
    {
        private readonly ListofFrozenFeedsVM listofFrozenFeedsVM;
        public FrozenFeedsController()
        {
            listofFrozenFeedsVM = new ListofFrozenFeedsVM();
        }

        [HttpGet]
        public IActionResult ListofFrozenFeeds()
        {

            return View(listofFrozenFeedsVM);
        }
    }
}
