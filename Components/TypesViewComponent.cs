using Microsoft.AspNetCore.Mvc;
using mission_9_CollinYoung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission_9_CollinYoung.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private BookRepository repo { get; set; }
        public TypesViewComponent (BookRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["projectType"];
            ViewBag.SelectedType = RouteData?.Values["projectType"];
            var types = repo.Books.Select(x => x.Category).Distinct().OrderBy(x => x);

            return View(types);
        }
    }
}
