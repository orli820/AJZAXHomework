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

        public ApiController (DemoContext context)
        {
            _context = context;
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
       
    }
}
