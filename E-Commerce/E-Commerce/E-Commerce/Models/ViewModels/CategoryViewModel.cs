using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string? Categoryname { get; set; }
        [Required]
        [Display(Name = "Category Image")]
        public IFormFile? Categoryimg { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
