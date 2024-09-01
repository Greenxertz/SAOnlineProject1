using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SAOnlineProject1.Models
{
    public class SummaryViewModel
    {

        public IEnumerable<UserCart>? userCartList { get; set; }

        public UserOrderHeader? orderSummery { get; set; }

        public string? cartUserId { get; set; }


        public string? SelectedPaymentOption { get; set; }

        public IEnumerable<SelectListItem>? PaymentOptions { get; set; } = new List<SelectListItem>
        {
        new SelectListItem { Text = "Card", Value = "Card" },
        new SelectListItem { Text = "EFT", Value = "EFT" }
        };     
    }
}
