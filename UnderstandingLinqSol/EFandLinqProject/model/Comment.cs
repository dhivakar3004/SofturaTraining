using System;
using System.Collections.Generic;
using System.Text;

namespace EFandLinqProject.model
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string CommenText { get; set; }
    }
}
