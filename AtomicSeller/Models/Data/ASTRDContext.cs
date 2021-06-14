
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomicSeller.Models.Data
{
    public class ASTRDEntities : DbContext
    {
        public ASTRDEntities()
        {

        }

        public ASTRDEntities(DbContextOptions<ASTRDEntities> options)
           : base(options)
        {
        }

        //public DbSet<jobs> jobs { get; set; }
    }
}
