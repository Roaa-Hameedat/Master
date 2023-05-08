using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? product { get; set; }
    }
}
