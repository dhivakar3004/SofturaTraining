using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSystem.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order order { get; set; }
        [ForeignKey("Pizza")]
        public int pizzaId { get; set; }
        public Pizza pizza { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Toppings { get; set; }
        [Required]
        public string CrustType { get; set; }

    }
}