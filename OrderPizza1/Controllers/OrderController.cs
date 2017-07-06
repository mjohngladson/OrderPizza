using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderPizza1.Models;
using OrderPizza1.ViewModel;
using WebGrease.Css.Extensions;

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
                PizzaSizes = _context.PizzaAttributes.Where(x => x.Name == "Size").Select(p => new SelectListItem { Text = p.Value + @"(" + p.Size + @" inch - $" + p.Amount + @")", Value = p.Id.ToString() }),
                PizzaCrusts = _context.PizzaAttributes.Where(x => x.Name == "Crust").Select(p => new SelectListItem { Text = p.Value + (Math.Abs(p.Amount) == 0 ? "" : @"(+ $" + p.Amount + @")"), Value = p.Id.ToString() }),
                PizzaToppings = _context.PizzaAttributes.Where(x => x.Name == "Toppings").Select(p => new SelectListItem { Text = p.Value + @"(+ $" + p.Amount + @")", Value = p.Id.ToString() }),
                PizzaTopping = _context.PizzaAttributes.Where(x => x.Name == "Toppings" && x.IsSelected).Select(p => p.Id).ToList()
            };
            return View(model);
        }

        [Authorize]
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
                    Topping = model.PizzaTopping != null ? string.Join(",", model.PizzaTopping) : null
                };
                _context.Pizzas.Add(pizza);
                _context.SaveChanges();

                customer = _context.Customers.First(c => c.Phone == (customer.Phone ?? model.Customer.Phone));
                pizza = _context.Pizzas.OrderByDescending(p => p.Id).First();

                var amount = _context.PizzaAttributes.FirstOrDefault(pa => pa.Id == model.PizzaSize).Amount + _context.PizzaAttributes.FirstOrDefault(pa => pa.Id == model.PizzaCrust).Amount + model.PizzaTopping.Sum(topping => _context.PizzaAttributes.FirstOrDefault(pa => pa.Id == topping).Amount);


                var order = new Order
                {
                    CustomerId = customer.Id,
                    PizzaId = pizza.Id
                };
                _context.Orders.Add(order);
                _context.SaveChanges();
                //return View();

                var redirecturl = "";

                //Mention URL to redirect content to paypal site
                redirecturl += "https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" +
                               ConfigurationManager.AppSettings["paypalemail"];

                //First name i assign static based on login details assign this value
                redirecturl += "&first_name=" + model.Customer.Name;

                //Product Name
                redirecturl += "&item_name=Pizza";

                //Product Name
                redirecturl += "&amount=" + amount;

                //Phone No
                redirecturl += "&night_phone_a=" + model.Customer.Phone;

                //Address 
                redirecturl += "&address1=" + model.Customer.Address + ", " + model.Customer.Zip;

                //Shipping charges if any
                //redirecturl += "&shipping=0";

                //Handling charges if any
                //redirecturl += "&handling=0";

                //Tax amount if any
                //redirecturl += "&tax=0";

                //Add quatity i added one only statically 
                //redirecturl += "&quantity=1";

                //Currency code 
                redirecturl += "&currency=$" + "currency";

                //Success return page url
                redirecturl += "&return=" +
                               ConfigurationManager.AppSettings["SuccessURL"];

                //Failed return page url
                redirecturl += "&cancel_return=" +
                               ConfigurationManager.AppSettings["FailedURL"];

                Response.Redirect(redirecturl);
            }
            model.PizzaSizes = _context.PizzaAttributes.Where(x => x.Name == "Size").Select(p => new SelectListItem
            {
                Text = p.Value + @"(" + p.Size + @" inch - $" + p.Amount + @")",
                Value = p.Id.ToString()
            });
            model.PizzaCrusts = _context.PizzaAttributes.Where(x => x.Name == "Crust").Select(p => new SelectListItem
            {
                Text = p.Value + (Math.Abs(p.Amount) == 0 ? "" : @"(+ $" + p.Amount + @")"),
                Value = p.Id.ToString()
            });
            model.PizzaToppings = _context.PizzaAttributes.Where(x => x.Name == "Toppings")
                .Select(p => new SelectListItem { Text = p.Value + @"(+ $" + p.Amount + @")", Value = p.Id.ToString() });

            return View("Index", model);
        }

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        [Authorize(Roles = "CanOrderPizza")]
        [HttpGet]
        public ActionResult Display()
        {
            var orders = GetOrders().ToList();
            return View(orders);
        }

        [Authorize(Roles = "CanOrderPizza")]
        [HttpPost]
        public bool Process(int id)
        {
            //List<OrderDisplayViewModel> orders;
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                //orders = GetOrders().ToList();
                //return View("Display", orders);
                return false;
            }
            order.Processed = true;
            _context.SaveChanges();

            //orders = GetOrders().ToList();
            //return View("Display", orders);
            return true;
        }

        [NonAction]
        private IEnumerable<OrderDisplayViewModel> GetOrders()
        {
            var orders = new List<OrderDisplayViewModel>();
            foreach (var o in _context.Orders.Where(o => o.Processed == false))
            {
                var viewModel = new OrderDisplayViewModel
                {
                    Order = new Order()
                    {
                        Id = o.Id,
                        Customer = _context.Customers.FirstOrDefault(c => o.CustomerId == c.Id),
                        Pizza = _context.Pizzas.FirstOrDefault(p => o.PizzaId == p.Id)
                    }
                };
                viewModel.PizzaSize = _context.PizzaAttributes.First(pa => pa.Id == viewModel.Order.Pizza.Size).Value;
                viewModel.PizzaCrust = _context.PizzaAttributes.First(pa => pa.Id == viewModel.Order.Pizza.Crust).Value;

                if (viewModel.Order.Pizza.Topping != null)
                {
                    foreach (var topping in viewModel.Order.Pizza.Topping.Split(','))
                    {
                        viewModel.PizzaTopping += ", " + _context.PizzaAttributes.First(pa => pa.Id.ToString() == topping).Value;
                    }
                    viewModel.PizzaTopping = viewModel.PizzaTopping.Substring(2, viewModel.PizzaTopping.Length - 2);
                }
                orders.Add(viewModel);
            }
            return orders;
        }
    }
}