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
        private PurchaseRepository repo { get; set; }
        private Basket basket { get; set; }
        public PurchaseController(PurchaseRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }



        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }
        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (basket.Item.Count == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty.");
            }
            if (ModelState.IsValid)
            {
                purchase.Lines = basket.Item.ToArray();
                repo.SavePurchase(purchase);
                basket.ClearBasket();
                return RedirectToPage("/PurchaseComplete");
            }
            else
            {
                return View();
            }
        }
    }
}
