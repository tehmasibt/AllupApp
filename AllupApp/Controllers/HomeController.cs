using AllupApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AllupApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
