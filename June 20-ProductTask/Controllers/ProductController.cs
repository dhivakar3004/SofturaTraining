using ProductTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProductTask.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            AdventureWorks2019Entities entities = new AdventureWorks2019Entities();
            CascadeProducts model = new CascadeProducts();
            foreach(var cat in entities.ProductCategories)
            {
                model.Category.Add(new SelectListItem
                {
                    Text = cat.Name,
                    Value = cat.ProductCategoryID.ToString()
                });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int? catId, int? subCatId, int? proId)
        {
            AdventureWorks2019Entities entities = new AdventureWorks2019Entities();
            CascadeProducts model = new CascadeProducts();
            foreach (var cat in entities.ProductCategories)
            {
                model.Category.Add(new SelectListItem
                {
                    Text = cat.Name,
                    Value = cat.ProductCategoryID.ToString()
                });
            }
            if (catId != null)
            {
                var scat = (from subcat in entities.ProductSubcategories
                            where subcat.ProductCategoryID == catId
                            select subcat).ToList();
                foreach(var sCategory in scat)
                {
                    model.SubCategory.Add(new SelectListItem { Text = sCategory.Name, Value = sCategory.ProductSubcategoryID.ToString() });
                }
                if(proId != null)
                {
                    var product = (from prod in entities.Products
                                   where prod.ProductID == proId.Value
                                   select prod).ToList();
                    foreach(var p in product)
                    {
                        model.Product.Add(new SelectListItem { Text = p.Name, Value = p.ProductID.ToString() });
                    }

                }
            }

            return View(model);
        }
    }
}