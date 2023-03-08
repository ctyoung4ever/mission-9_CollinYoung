using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission_9_CollinYoung.Models;
using mission_9_CollinYoung.Models.ViewModels;
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

        public IActionResult Index(string projectType, int pagenum = 1)
        {
            int pagesize = 10;
            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(p => p.Category == projectType || projectType == null)
                .OrderBy(b => b.Title)
                .Skip((pagenum - 1) * pagesize)
                .Take(pagesize)
            ,
                PageInfo = new PageInfo
                {
                    TotalNumBooks = (projectType == null ? 
                    repo.Books.Count() : 
                    repo.Books.Where(x => x.Category == projectType).Count()),
                    BooksPerPage = pagesize,
                    CurrentPage = pagenum
                }
            };
          
            return View(x);
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
