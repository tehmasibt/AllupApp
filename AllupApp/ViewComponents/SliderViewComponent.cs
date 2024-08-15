using AllupApp.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AllupApp.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly AllupAppDbContext _context;
        public SliderViewComponent(AllupAppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var sliders= await _context.Sliders.Take(count).ToListAsync();
            return View(await Task.FromResult(sliders));
        }
    }
}
