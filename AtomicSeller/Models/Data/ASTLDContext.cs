
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomicSeller.Models.Data
{
    public class ASTLDEntities : DbContext
    {
        public ASTLDEntities()
        {

        }

        public ASTLDEntities(DbContextOptions<ASTLDEntities> options)
           : base(options)
        {
        }

        //public DbSet<jobs> jobs { get; set; }
    }
}
