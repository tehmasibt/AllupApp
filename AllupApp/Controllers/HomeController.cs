using AllupApp.App_Data;
using AllupApp.Models;
using AllupApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AllupApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AllupAppDbContext _context;

        public HomeController(AllupAppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM();
            vm.Categories = await _context.Categories.Where(p => !p.IsDeleted && p.IsMain).ToListAsync();
            vm.BestSellerProducts = await _context.Products.Where(b => !b.IsDeleted && b.IsBestSeller).ToListAsync();
            vm.NewProducts = await _context.Products.Where(b => !b.IsDeleted && b.IsNewArrival).ToListAsync();
            vm.FeaturedProducts = await _context.Products.Where(b => !b.IsDeleted && b.IsFeatured).ToListAsync();
            return View(vm);
        }
    }
}
