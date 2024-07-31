using AllupApp.Models;

namespace AllupApp.Interfaces
{
    public interface ILayoutService
    {
        IDictionary<string, string> GetSettings();
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}