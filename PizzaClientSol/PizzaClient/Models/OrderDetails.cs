using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaClient.Models
{

    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }

        public int PizzaId { get; set; }
        [ForeignKey("PizzaId")]


        [Required (ErrorMessage="Customer Name is Required")]
        [StringLength(25,MinimumLength =4)]
        [Display(Name = "Customer Name")]
        //[RegularExpression(@"(\S\D)+", ErrorMessage ="Number and Spaces Not allowed")]
        public string CustomerName { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "Phone number should be 10 digits")]
        [Display(Name = "Phone Number")]       
        public String PhoneNumber { get; set; }


        [Required (ErrorMessage ="Address is Required")]
        public string Address { get; set; }


        [Required]
        public string Crust { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        
        [Required]
        public string Toppings { get; set; }

        [Required]
        [Display(Name = "Delivery Date")]
        public DateTime DeliveryDate { get; set; }
        [Required(ErrorMessage="Select quantity to see the amount")]
        public float Amount { get; set; }
    }
}
