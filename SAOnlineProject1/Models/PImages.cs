using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAOnlineProject1.Models
{
    public class PImages
    {
        [Required]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public string ImageUrl { get; set; }

        public string ProductName { get; set; }
    }
}
