using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCWebServer.Context;

namespace MVCWebServer.Controllers
{
 
    public class HomeController : Controller
    {
        private readonly MyDbContext myDbContext = new MyDbContext();
        public IActionResult Index()
        {
             var category = myDbContext.Users.First();
            //myDbContext.Users.First();
            return View();
        }

    }
}