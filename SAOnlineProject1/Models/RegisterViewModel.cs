using System.ComponentModel.DataAnnotations;

namespace SAOnlineProject1.Models
{
    public class RegisterViewModel
    {
        public ApplicationUser User { get; set; }

        public string StatusMessage { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage  = "Passwords did not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
