﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAOnlineProject1.Models
{
    public class Inventory
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 999.99, ErrorMessage = "Range 1 to 999.99 only")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$", ErrorMessage = "Please insert two digits after decimal. Example: 0.00")]
        public double Purchase_Price { get; set; }

             
        public string Category { get; set; }

        public int Quantity { get; set; }

    }
}
