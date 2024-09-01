using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAOnlineProject1.Models
{
    public class UserOrderHeader
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public string? UserId { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public DateTime DateOfOrder { get; set; }

        [Required]
        public DateTime DateOfShipped { get; set; }
       

        public double TotalOrderAmount { get; set; }

        public string? TrackingNumber { get; set; }

        public string? Carrier { get; set; }

        public string? OrderStatus { get; set; }

        public string? PaymentStatus { get; set; }

        public DateTime? PaymentProccessDate { get; set; }

        public string? TransactionId { get; set; }
        [Required]

        public string PhoneNumber { get; set; }
        [Required]

        public string DeliveryStreetAddress { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public string Province { get; set; }
        [Required]

        public string PostalCode { get; set; }
        [Required]

        public string Name { get; set; }
    }
}
