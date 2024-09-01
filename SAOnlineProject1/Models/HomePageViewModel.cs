namespace SAOnlineProject1.Models
{
    public class HomePageViewModel
    {
       public IEnumerable<Product> ProductList { get; set; }
       public IEnumerable<Category> Categories { get; set; }
       public string searchByName { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalProducts { get; set; }
    }
}
