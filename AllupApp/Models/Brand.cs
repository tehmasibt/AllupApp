using System.ComponentModel.DataAnnotations;

namespace AllupApp.Models
{
    public class Brand : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
