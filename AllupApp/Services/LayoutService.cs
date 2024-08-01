using AllupApp.App_Data;
using AllupApp.Interfaces;
using AllupApp.Models;
using AllupApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AllupApp.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly AllupAppDbContext _allupAppDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LayoutService(AllupAppDbContext allupAppDbContext , IHttpContextAccessor httpContextAccessor)
        {
            _allupAppDbContext = allupAppDbContext;
            _httpContextAccessor = httpContextAccessor; 
        }
        public IEnumerable<BasketVM> GetBasket()

        {
            List<BasketVM> list = new List<BasketVM>();
            string basket = _httpContextAccessor.HttpContext.Request.Cookies["basket"];
            if (string.IsNullOrWhiteSpace(basket))
                return list;
            else
            {
                list = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                foreach (var item in list)
                {
                    var existProduct = _allupAppDbContext.Products.FirstOrDefault(p => p.Id == item.Id);
                    item.Name = existProduct.Name;
                    item.Price = existProduct.DisCountPrice > 0 ? existProduct.DisCountPrice : existProduct.Price;
                    item.Image=existProduct.MainImage;
                    item.ExTax = existProduct.ExTax;
                }
                return list;
            }
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories = await _allupAppDbContext.Categories
                .AsNoTracking()
                .Where(a => !a.IsDeleted)
                .Include(c => c.Children)
                .ToListAsync();
            return categories;
        }
        public IDictionary<string, string> GetSettings()
        {
            return _allupAppDbContext.Settings
               .Where(s => !s.IsDeleted)
               .ToDictionary(s => s.Key, s => s.Value);
        }
    }
}
