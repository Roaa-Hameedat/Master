using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string? Productname { get; set; }
        [Required]
        [Display(Name = "Product Description")]
        public string? Productdescription { get; set; }
        [Required]
        [Display(Name = "Product Price")]
        public decimal Productprice { get; set; }
        [Required]
        [Display(Name = "Product Image")]
        public IFormFile? Productimg { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? category { get; set; }
    }
}
