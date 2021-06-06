using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductClient.Models
{
    public partial class Product
    {
        [Key]
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public float Ratings { get; set; }
        public string Description { get; set; }
    }
}
