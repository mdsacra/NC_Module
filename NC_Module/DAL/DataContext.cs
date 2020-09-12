﻿using Microsoft.EntityFrameworkCore;
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

       
    }
}
