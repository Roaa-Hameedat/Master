using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        public string? CustomerName { get; set; }
        [Required]
        [Display(Name = "Customer Phone")]
        public string? CustomerPhone { get; set;}
        [Required]
        [Display(Name = "Customer City")]
        public string? CustomerCity { get; set;}
        [Required]
        [Display(Name = "Visa Number")]
        [StringLength(16, MinimumLength = 16)]
        public string? Visa { get; set; }
        public decimal Totalamount { get; set; }




    }
}
