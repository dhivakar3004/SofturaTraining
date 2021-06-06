using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBAccountClient.Models;

namespace SBAccountClient.Data
{
    public class SBAccountClientContext : DbContext
    {
        public SBAccountClientContext (DbContextOptions<SBAccountClientContext> options)
            : base(options)
        {
        }

        public DbSet<SBAccountClient.Models.Account> Account { get; set; }
    }
}
