using AllupApp.App_Data;
using AllupApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AllupApp.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AllupAppDbContext _context;
        public HeaderViewComponent(AllupAppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(HeaderVM headerVM)
        {
            return View(await Task.FromResult(headerVM));
        }
    }
}
