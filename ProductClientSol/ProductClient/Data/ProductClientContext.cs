using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using ProductClient.Models;

namespace ProductClient.Data
{
    public class ProductClientContext : DbContext
    {
        public ProductClientContext (DbContextOptions<ProductClientContext> options)
            : base(options)
        {
        }

        public DbSet<ProductClient.Models.Product> Product { get; set; }
    }
}
