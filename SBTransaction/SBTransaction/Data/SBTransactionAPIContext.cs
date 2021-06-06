using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBTransactionAPI.Models;

namespace SBTransactionAPI.Data
{
    public class SBTransactionAPIContext : DbContext
    {
        public SBTransactionAPIContext (DbContextOptions<SBTransactionAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SBTransactionAPI.Models.AccountTrans> AccountTrans { get; set; }
    }
}
