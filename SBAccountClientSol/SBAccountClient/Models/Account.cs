using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SBAccountClient.Models
{
    public class Account
    {
        public double AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public float CurrentBalance { get; set; }
    }
}
