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
        // GET: Order
        public ActionResult Index()
        {
            //var pizzaSizes = new List<SelectListItem>();
            //foreach (var size in _context.PizzaAttributes.Where(x => x.Name == "Size"))
            //{
            //    pizzaSizes.Add(new SelectListItem() { Value = size.Id.ToString(), Text = size.Value });
            //}
            //var pizzaCrusts = new List<SelectListItem>();
            //foreach (var crust in _context.PizzaAttributes.Where(x => x.Name == "Crust"))
            //{
            //    pizzaCrusts.Add(new SelectListItem() { Value = crust.Id.ToString(), Text = crust.Value });
            //}
            //var pizzaToppings = new List<SelectListItem>();
            //foreach (var topping in _context.PizzaAttributes.Where(x => x.Name == "Topping"))
            //{
            //    pizzaToppings.Add(new SelectListItem() { Value = topping.Id.ToString(), Text = topping.Value });
            //}
            var model = new PizzaPizzaAttributesViewModel
            {
                PizzaSizes = _context.PizzaAttributes.Where(x => x.Name == "Size"),
                PizzaCrusts = _context.PizzaAttributes.Where(x => x.Name == "Crust"),
                PizzaToppings = _context.PizzaAttributes.Where(x => x.Name == "Topping"),
                SelectedToppings = _context.PizzaAttributes.Where(x => x.Name == "Topping").Select(y => y.IsSelected),
                Customer = new Customer()
            };
            return View(model);
        }

        public void Save()
        {

        }
    }
}