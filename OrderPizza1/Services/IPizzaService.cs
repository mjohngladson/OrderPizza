using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderPizza1.Models;

namespace OrderPizza1.Services
{
    interface IPizzaService
    {
        IEnumerable<PizzaAttribute> GetPizzaAttributes(string name);
    }
}