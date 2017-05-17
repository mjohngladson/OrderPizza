using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderPizza1.Models;

namespace OrderPizza1.Repository
{
    interface IPizzaRepository
    {
        IEnumerable<PizzaAttribute> GetPizzaAttributes(string name);
    }
}
