using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrderPizza1.Models
{
    public class PizzaTopping
    {
        [Key, Column(Order = 1)]
        public int Pizza { get; set; }
        [Key, Column(Order = 2)]
        public int Topping { get; set; }
    }
}