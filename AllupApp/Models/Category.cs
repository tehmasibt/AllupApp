using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace AllupApp.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string Image { get; set; }
        public int? ParentId { get; set; }
        public bool IsMain { get; set; }
        public Category Parent { get; set; }
        public List<Category> Children { get; set; }
        public List<Product> Products { get; set; }
    }
}
