using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaOrder.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }

        public int PizzaId { get; set; }
        [ForeignKey("PizzaId")]
        //public  Pizza Pizza { get; set; }
        
        public string CustomerName { get; set; }
        
        [Required(ErrorMessage = "Address is Required")]

        [StringLength(10)]
        public String PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }

        public string Crust { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Toppings { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required(ErrorMessage = "Select quantity to see the amount")]
        public float Amount { get; set; }



    }

}