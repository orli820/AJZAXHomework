using AJZAXHomework.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJZAXHomework.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        private readonly NorthwindContext _Ncontext;

        public ApiController (DemoContext context,NorthwindContext Ncontext)
        {
            _context = context;
            _Ncontext = Ncontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult checkname(string name)
        {
            var exists = _context.Members.Any(n => n.Name == name);
            return Content(exists.ToString(), "text/plain");
        }

        public IActionResult city( )
        {
            var city = _context.Addresses.Select(c => c.City).Distinct();
            return Json(city);
        }

        public IActionResult site(string city)
        {
            var site = _context.Addresses.Where(s=>s.City==city).Select(c => c.SiteId).Distinct();
            return Json(site);
        }
        public IActionResult road(string site)
        {
            var road = _context.Addresses.Where(s => s.SiteId == site).Select(c => c.Road).Distinct();
            return Json(road);
        }

        public IActionResult search(string keyword)
        {
            var key = _Ncontext.Products.Where(p => p.ProductName.Contains(keyword)).Select(p => p.ProductName);
            return Json(key);
        }
    }
}
