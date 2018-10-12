using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    [HandleError]
    public class BuyBitcoinController : Controller
    {
        //
        // GET: /BuyBitcoin/

        public ActionResult Index()
        {
            ViewModels.BuyBitcoinViewModel buyViewModel = new ViewModels.BuyBitcoinViewModel();
            buyViewModel.FiatBalance = 100;
            buyViewModel.Price = 660;

            return View(buyViewModel);
        }
    }
}