using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoAutoService.Controllers
{
    public class ContactClientController : Controller
    {
        public IActionResult ContactClient()
        {
            return View();
        }
    }
}
