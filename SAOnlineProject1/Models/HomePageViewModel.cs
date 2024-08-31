namespace SAOnlineProject1.Models
{
    public class HomePageViewModel
    {
       public IEnumerable<Product> ProductList { get; set; }
       public IEnumerable<Category> Categories { get; set; }
       public string searchByName { get; set; }
    }
}
