using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TepeGuvCase.WebUI.Tools
{
    public class CartItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short Amount { get; set; }
        public decimal SubTotal { get { return Price * Amount; } }
    }
}