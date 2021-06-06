using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace task1inWebApp.Models
{   
    public class UserModel
    {   [Key]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }
    }

}