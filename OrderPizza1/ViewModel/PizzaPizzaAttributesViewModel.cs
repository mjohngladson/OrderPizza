using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderPizza1.Models;

namespace OrderPizza1.ViewModel
{
    public class PizzaPizzaAttributesViewModel
    {
        [Display(Name = "Size")]
        public int PizzaSize { get; set; }
        public IEnumerable<SelectListItem> PizzaSizes { get; set; }

        [Display(Name = "Crust")]
        public int PizzaCrust { get; set; }
        public IEnumerable<SelectListItem> PizzaCrusts { get; set; }

        [Display(Name = "Topping")]
        public IEnumerable<int> PizzaTopping { get; set; }
        public IEnumerable<SelectListItem> PizzaToppings { get; set; }
        public IEnumerable<int> SelectedTopping { get; set; }

        [Display(Name = "Payment Method")]
        [Required]
        public int? PaymentMethod { get; set; }
        public IEnumerable<SelectListItem> PaymentMethods { get; set; }
        public Customer Customer { get; set; }
    }
}