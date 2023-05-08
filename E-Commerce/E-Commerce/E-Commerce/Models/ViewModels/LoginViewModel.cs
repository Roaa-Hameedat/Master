using System.ComponentModel.DataAnnotations;

namespace E_Commerce.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
