using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SBAccount.Models
{
    public class Account
    {   [Key]
        public int ID { get; set; }
        public double AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public float CurrentBalance { get; set; }
    }
}
