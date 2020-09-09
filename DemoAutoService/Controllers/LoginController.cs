using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoAutoService.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            if (Startup.isLogged == true)
                Startup.isLogged = false;
            return View();
        }



        public IActionResult VerifyData(string username,string password)
        {
            Console.WriteLine("->"+username + ":" + password);
            if (username == "admin")
            {
                if (password == "1234")
                { Startup.isLogged = true; return RedirectToAction("Index", "Home"); }
                else return RedirectToAction("Login");
            }
            else return RedirectToAction("Login");
            
        
        
        
        }



    }
}