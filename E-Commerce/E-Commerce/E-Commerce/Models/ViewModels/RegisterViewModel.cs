using System.ComponentModel.DataAnnotations;

namespace E_Commerce.ViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and  Confirm Not Match")]
        [Required]
        public string? ConfirmPassword { get; set; }
    }
}
