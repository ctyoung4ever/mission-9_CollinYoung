using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission_9_CollinYoung.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission_9_CollinYoung.Controllers
{
    public class HomeController : Controller
    {
        private BookRepository repo;

        public HomeController(BookRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            var db = repo.Books.ToList();
            return View(db);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
