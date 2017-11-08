using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMSWebApp.Controllers
{
    //[Produces("application/json")]
    //[Route("api/System")]
    public class SystemController : Controller
    {
        public IActionResult Species()
        {
            return View();
        }
    }
}