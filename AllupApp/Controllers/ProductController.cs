using AllupApp.App_Data;
using AllupApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AllupApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AllupAppDbContext _allupAppDbContext;
        public ProductController(AllupAppDbContext allupAppDbContext)
        {
            _allupAppDbContext = allupAppDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Modal(int? id)
        {
            if (id == null) return BadRequest();
            var product = await _allupAppDbContext.Products
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .Include(a => a.ProductImages)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return NotFound();
            return PartialView("_ModalPartial", product);
        }
        public IActionResult SearchProduct(int? categoryId, string search)
        {
            if(categoryId != null)
            {
                if(_allupAppDbContext.Categories.Any(c=>c.Id == categoryId))
                    return BadRequest();
            }
            var products = _allupAppDbContext.Products
                .AsNoTracking()
                .Where(p => !p.IsDeleted &&
                categoryId != null ? p.CategoryId == categoryId : true &&
                (p.Name.ToLower().Contains(search.ToLower())
                || p.Brand.Name.ToLower().Contains(search.ToLower())))
                .ToList();
            return PartialView("_SearchPartial", products);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();
            var product = await _allupAppDbContext.Products
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .Include(a => a.ProductImages)
                .Include(a => a.Brand)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }
    }
}
