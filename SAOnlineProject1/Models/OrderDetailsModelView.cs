namespace SAOnlineProject1.Models
{
    public class OrderDetailsModelView
    {
        public UserOrderHeader? UserOrderHeader { get; set; }

        public IEnumerable<OrderDetails> UserProductList { get; set; }

    }
}
