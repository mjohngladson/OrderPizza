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
        public int Size { get; set; }
        public int Crust { get; set; }
        public string Topping { get; set; }

        //navigation property
        //public virtual ICollection<PizzaAttribute> PizzaAttributes { get; set; }
    }
}