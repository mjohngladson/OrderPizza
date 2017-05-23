using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderPizza1.Models;

namespace OrderPizza1.ViewModel
{
    public class OrderDisplayViewModel
    {
        public Order Order { get; set; }
        public string PizzaSize { get; set; }
        public string PizzaCrust { get; set; }
        public string PizzaTopping { get; set; }
    }
}