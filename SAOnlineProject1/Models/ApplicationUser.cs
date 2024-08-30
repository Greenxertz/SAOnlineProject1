using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SAOnlineProject1.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Required]
        public string? Address { get; set; }
        
        public string? City { get; set; }

        [Required]
        public string? PostalCode { get; set; }
        
        [Required]
        public string? Province { get; set; }



    }
}
