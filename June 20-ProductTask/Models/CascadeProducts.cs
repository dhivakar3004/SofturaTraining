using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductTask.Models
{
    public class CascadeProducts
    {   

        public CascadeProducts()
        {
            this.Category = new List<SelectListItem>();
            this.SubCategory = new List<SelectListItem>();
            this.Product = new List<SelectListItem>();
        }
        public List<SelectListItem> Category { get; set; }
        public List<SelectListItem> SubCategory { get; set; }

        public List<SelectListItem> Product { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int ProductId { get; set; }

    }
}