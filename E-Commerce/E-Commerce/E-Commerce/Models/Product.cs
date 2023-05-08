using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string? Productname { get; set; }
        [Required]
        [Display(Name = "Product Description")]
        public string? Productdescription { get; set;}
        [Required]
        [Display(Name = "Product Price")]
        public decimal Productprice { get; set;}
        [Required]
        [Display(Name = "Product Image")]
        public string? Productimg { get; set;}
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? category { get; set; }
    }
}
