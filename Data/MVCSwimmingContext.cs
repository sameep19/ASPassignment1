using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using swimming.Models;

    public class MVCSwimmingContext : DbContext
    {
        public MVCSwimmingContext (DbContextOptions<MVCSwimmingContext> options)
            : base(options)
        {
        }

        public DbSet<swimming.Models.Swimming> Swimming { get; set; }
    }
