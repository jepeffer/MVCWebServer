using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCWebServer.Context;
using MVCWebServer.Models;

namespace MVCWebServer.Controllers
{
 
    public class HomeController : Controller
    {
        [RequireHttps]
        public IActionResult Index()
        {
            //myDbContext.Users.First();
            User userModel = new User() { auth = false };
            return View(userModel);
        }

        public IActionResult Landing (User userModel)
        {
            return View(userModel);
        }
    }
}