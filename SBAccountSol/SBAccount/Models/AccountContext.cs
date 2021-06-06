using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SBAccount.Models
{   public class AccountContext:DbContext
    {
        public AccountContext():base()
        {

        }
        public AccountContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
    }

}