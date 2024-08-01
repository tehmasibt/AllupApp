using AllupApp.App_Data;
using AllupApp.Models;
using AllupApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AllupApp.Controllers
{
    public class BasketController : Controller
    {
        private readonly AllupAppDbContext _context;

        public BasketController(AllupAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id == null) BadRequest();
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            string basket = HttpContext.Request.Cookies["basket"];
            List<BasketVM> baskets;
            if (string.IsNullOrWhiteSpace(basket))
            {
                baskets = new();
            }
            else
            {
                baskets = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            }
            if(baskets.Exists(p => p.Id == id))
            {
                var basketProduct=baskets.FirstOrDefault(p => p.Id == id);
                basketProduct.Count++;
            }
            else
            {
                baskets.Add(new BasketVM() { Id = product.Id, Name = product.Name, Price = product.Price, Image = product.MainImage, Count = 1 });
            }
            HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(baskets));
            return PartialView("_BasketPartial", baskets);
        }
        public IActionResult GetBasket()
        {
            var result = HttpContext.Request.Cookies["basket"];
            return Json(result);
        }
    }
}
