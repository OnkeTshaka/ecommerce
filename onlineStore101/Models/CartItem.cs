using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onlineStore101.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public CartItem(Product product, int quanity)
        {
            Product = product;
            Quantity = quanity;
        }
    }
}