using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModuleCore.Hubs;

namespace ModuleCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CSharp_View() 
        {
            return View();
        }

        public IActionResult TestFunction_View()
        {
            //換到別的controller的方法
            return RedirectToAction("TestFunction_Index", "TestFunction");
        }

        public IActionResult MVCCORE_View()
        {
            return View();
        }
    }
}
