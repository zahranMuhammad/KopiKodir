using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeShop.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.controllers
{
    public class DashboardController : Controller
    {
        [Auth]
        public IActionResult Index()
        {
            return View("~/Views/Dashboard.cshtml");
        }
    }
}