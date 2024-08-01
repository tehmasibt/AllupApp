using AllupApp.Models;
using AllupApp.ViewModels;

namespace AllupApp.Interfaces
{
    public interface ILayoutService
    {
        IDictionary<string, string> GetSettings();
        Task<IEnumerable<Category>> GetCategoriesAsync();
        IEnumerable<BasketVM> GetBasket();
    }
}