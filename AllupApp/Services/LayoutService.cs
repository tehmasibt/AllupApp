using AllupApp.App_Data;
using AllupApp.Interfaces;
using AllupApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AllupApp.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly AllupAppDbContext _allupAppDbContext;

        public LayoutService(AllupAppDbContext allupAppDbContext)
        {
            _allupAppDbContext = allupAppDbContext;
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
