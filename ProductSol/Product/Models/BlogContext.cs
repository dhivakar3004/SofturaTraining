using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;



namespace ProductAPI.Models
{
    public class BlogContext:DbContext
    {
       
        public BlogContext() : base()
        {

        }
        public BlogContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Blog> Blogs { get; set; }
    }
}