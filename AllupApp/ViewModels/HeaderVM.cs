using AllupApp.Models;

namespace AllupApp.ViewModels
{
    public class HeaderVM
    {
        public IEnumerable<BasketVM> Basket { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IDictionary<string, string> Settings { get; set; }
    }
}
