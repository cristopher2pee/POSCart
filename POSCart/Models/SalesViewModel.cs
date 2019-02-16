using System;
using System.Collections.Generic;
using System.Text;

namespace POSCart.Models
{
    public class SalesViewModel
    {
        public int ProductId { get; set; }
        public string ProductDetailName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
