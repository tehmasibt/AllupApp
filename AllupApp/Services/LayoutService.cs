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
        public IDictionary<string, string> GetSettings()
        {
            return _allupAppDbContext.Settings
               .Where(s => !s.IsDeleted)
               .ToDictionary(s => s.Key, s => s.Value);
        }
    }
}
