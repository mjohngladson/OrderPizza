using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderPizza1.Models;
using OrderPizza1.ViewModel;

namespace OrderPizza1.Controllers
{
    public class OrderController : Controller
    {
        readonly ApplicationDbContext _context;
        public OrderController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        [HttpGet]
        // GET: Order
        public ActionResult Index()
        {
            var model = new PizzaPizzaAttributesViewModel
            {
                PizzaSizes = _context.PizzaAttributes.Where(x => x.Name == "Size").Select(p => new SelectListItem { Text = p.Value, Value = p.Id.ToString() }),
                PizzaCrusts = _context.PizzaAttributes.Where(x => x.Name == "Crust").Select(p => new SelectListItem { Text = p.Value, Value = p.Id.ToString() }),
                PizzaToppings = _context.PizzaAttributes.Where(x => x.Name == "Topping").Select(p => new SelectListItem { Text = p.Value, Value = p.Id.ToString() }).ToList(),
                PizzaTopping = _context.PizzaAttributes.Where(x => x.Name == "Topping" && x.IsSelected).Select(p => p.Id).ToList()
            };
            return View(model);
        }

        [Authorize(Roles = "CanOrderPizza")]
        [HttpPost]
        public ActionResult Save(PizzaPizzaAttributesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer();
                if (!_context.Customers.Any(c => c.Phone == model.Customer.Phone))
                {
                    customer = new Customer
                    {
                        Name = model.Customer.Name,
                        Address = model.Customer.Address,
                        Zip = model.Customer.Zip,
                        Phone = model.Customer.Phone
                    };
                    _context.Customers.Add(customer);
                }
                var pizza = new Pizza
                {
                    Size = model.PizzaSize,
                    Crust = model.PizzaCrust,
                    Topping = string.Join(",", model.PizzaTopping)
                };
                _context.Pizzas.Add(pizza);
                _context.SaveChanges();

                customer = _context.Customers.First(c => c.Phone == (customer.Phone ?? model.Customer.Phone));
                pizza = _context.Pizzas.OrderByDescending(p => p.Id).First();
                var order = new Order
                {
                    CustomerId = customer.Id,
                    PizzaId = pizza.Id
                };
                _context.Orders.Add(order);
                _context.SaveChanges();
                return View();
            }
            model.PizzaSizes = _context.PizzaAttributes.Where(x => x.Name == "Size").Select(p => new SelectListItem { Text = p.Value, Value = p.Id.ToString() });
            model.PizzaCrusts = _context.PizzaAttributes.Where(x => x.Name == "Crust").Select(p => new SelectListItem { Text = p.Value, Value = p.Id.ToString() });
            model.PizzaToppings = _context.PizzaAttributes.Where(x => x.Name == "Topping").Select(p => new SelectListItem { Text = p.Value, Value = p.Id.ToString() });
            return View("Index", model);
        }
    }
}