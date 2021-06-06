using EFandLinqProject.model;
using EFandLinqProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFandLinqProject.model
{
    public class TweetContext: dbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!OptionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=LAPTOP-874O3SVO\SQLEXPRESS;Integrated Security=true;Database =dbTweet");
            }
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public DbSet<Post> posts { get; set; }
        public DbSet<Comment>Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Post>().HasData(new Post
            {
                Id = 1;
            PostText = "Test";
            Category = "Info";
            });
        }

    }
}
