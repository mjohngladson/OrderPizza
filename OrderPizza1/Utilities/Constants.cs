using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderPizza1.Utilities
{
    public class Constants
    {
    }

    public class Size
    {
        public static readonly string Small = "Small";
        public static readonly string Medium = "Medium";
        public static readonly string Large = "Large";
    }

    public class Crust
    {
        public static readonly string Regular = "Regular";
        public static readonly string Thin = "Thin";
        public static readonly string Thick = "Thick";
    }

    public class Toppings
    {
        public static readonly string Sausage = "Sausage";
        public static readonly string Pepperoni = "Pepperoni";
        public static readonly string Onions = "Onions";
        public static readonly string GreenPeppers = "Green Peppers";
    }
}