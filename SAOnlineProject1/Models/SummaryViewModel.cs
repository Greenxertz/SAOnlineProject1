using Microsoft.AspNetCore.Mvc.Rendering;

namespace SAOnlineProject1.Models
{
    public class SummaryViewModel
    {

        public IEnumerable<UserCart>? userCartList { get; set; }

        public UserOrderHeader? orderSummery { get; set; }

        public string? cartUserId { get; set; }

        public IEnumerable<SelectListItem>? paymentOptions { get; set; }

        public double? PaymentPaidByCard { get; set; } = 0.0;
    }
}
