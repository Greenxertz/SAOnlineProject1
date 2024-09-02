using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAOnlineProject1.Models
{
    public class OrderDetails
    {

        [Key]

        public int Id { get; set; }
        [Required]

        public int OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]

        public UserOrderHeader? OrderHeader { get; set; }
        [Required]

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]

        public Product? Product { get; set; }
       
        public int Count { get; set; }
       
        [Required]

        public double Price { get; set; }  
    }
}
