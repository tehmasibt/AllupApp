using AllupApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllupApp.Controllers
{
    public class AboutController : Controller
    {
        private readonly LayoutService layoutService;

        public AboutController(LayoutService layoutService)
        {
            this.layoutService = layoutService;
        }

        public IActionResult Index()
        {
            return View(layoutService.GetSettings());
        }
    }
}
