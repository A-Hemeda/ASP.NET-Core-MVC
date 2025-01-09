using System.ComponentModel.DataAnnotations;

namespace MVC.PL.Models
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; }
        public string Token { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6)]
        [Compare(nameof(Password), ErrorMessage = "Mismatch Password")]

        public string ConfirmPassword { get; set; }
    }
}
