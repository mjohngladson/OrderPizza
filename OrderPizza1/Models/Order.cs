using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrderPizza1.Models
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Pizza")]
        public int PizzaId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        //Navigation property
        public Customer Customer { get; set; }
        public Pizza Pizza { get; set; }
    }
}