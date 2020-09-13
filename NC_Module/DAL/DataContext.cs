using Microsoft.EntityFrameworkCore;
using NC_Module.ModelDTO;
using NC_Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC_Module.DAL
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<NonConf> nonConfs { get; set; }
        public DbSet<CorrAction> corrActions { get; set; }
        public DbSet<NonConfCorrActions> nonConfCorrActions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NonConfCorrActions>().HasKey(nc => new { nc.CorrActionId, nc.NonConfId });
                        
                        
                        
                        
        }

    }
}
