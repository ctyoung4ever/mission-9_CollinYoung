using Microsoft.AspNetCore.Mvc;
using mission_9_CollinYoung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission_9_CollinYoung.Controllers
{
    public class PurchaseController : Controller
    {
        public PurchaseController()
        {

        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }
        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {

        }
    }
}
