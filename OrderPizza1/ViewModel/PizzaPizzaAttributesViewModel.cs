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
        public IEnumerable<PizzaAttribute> PizzaSizes { get; set; }
        [Display(Name = "Crust")]
        public IEnumerable<PizzaAttribute> PizzaCrusts { get; set; }
        [Display(Name = "Topping")]
        public IEnumerable<PizzaAttribute> PizzaToppings { get; set; }
        public IEnumerable<bool> SelectedToppings { get; set; }
        public Customer Customer { get; set; }
    }
}