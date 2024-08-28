using System.ComponentModel.DataAnnotations;

namespace SAOnlineProject1.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage ="Length cannot go above 30 characters")]
        public string Name { get; set; }

    }
}
