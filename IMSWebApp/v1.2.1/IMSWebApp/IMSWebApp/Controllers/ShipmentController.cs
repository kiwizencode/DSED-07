using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IMSWebApp.Controllers
{
    public class ShipmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Supplier()
        {
            return View();
        }
    }
}