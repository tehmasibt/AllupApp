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
    }
}
