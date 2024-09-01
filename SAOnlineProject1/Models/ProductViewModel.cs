using Microsoft.AspNetCore.Mvc.Rendering;

namespace SAOnlineProject1.Models
{
    public class ProductViewModel
    {
        public Product? Products { get; set; }

        public IEnumerable<SelectListItem>? CategoriesList { get; set; }
        
        public IEnumerable<IFormFile>? Images { get; set; }
        
        public Inventory? Inventories { get; set; }

        public PImages? PImages { get; set; }

        public List<PImages>? ImgUrls { get; set; }
    }
}
