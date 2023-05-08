using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [Display(Name ="Category Name")]
        public string? Categoryname { get; set; }
        [Required]
        [Display(Name = "Category Image")]
        public string? Categoryimg { get; set; }
        public ICollection<Product>? Products { get; set;}
    }
}
