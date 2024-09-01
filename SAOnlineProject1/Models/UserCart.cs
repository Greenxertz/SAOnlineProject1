using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAOnlineProject1.Models
{
    public class UserCart
    {
        [Key]
        public int Id { get; set; }

        
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product product { get; set; } 

      
        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; } 

         
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        public int Quantity { get; set; }

        
        [NotMapped]
        public double Price { get; set; }
    }
}
