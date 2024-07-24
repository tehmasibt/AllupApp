using System.ComponentModel.DataAnnotations;

namespace AllupApp.Models
{
    public class Setting : BaseEntity
    {
        [Required]
        public string Key { get; set; }
        [MaxLength(1500)]
        public string Value { get; set; }
    }
}
