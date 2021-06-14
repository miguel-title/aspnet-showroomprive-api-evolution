
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomicSeller.Models.Data
{
    public class ASTJLEntities : DbContext
    {
        public ASTJLEntities()
        {

        }

        public ASTJLEntities(DbContextOptions<ASTJLEntities> options)
           : base(options)
        {
        }

        //public DbSet<jobs> jobs { get; set; }
    }
}
