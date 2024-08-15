using AllupApp.App_Data;
using Microsoft.AspNetCore.Mvc;

namespace AllupApp.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AllupAppDbContext _context;

        public FooterViewComponent(AllupAppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(IDictionary<string, string> settings)
        {
            return View(await Task.FromResult(settings));
        }
    }
}
