using EFandLinqProject.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFandLinqProject
{
    public class Post
    {
        public int Id { get; set; }
        public string PostText { get; set; }
        public string Category { get; set; }
        public ICollection<Comment> comments { get; set; }
    }
}
