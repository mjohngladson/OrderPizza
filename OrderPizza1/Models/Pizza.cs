using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderPizza1.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string Crust { get; set; }
        public string Toppings { get; set; }
    }
}