using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeNew.Models.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace DeNew.Models
{
    public class DeContext : DbContext
    {

        public DbSet<Page> Pages { get; set; }
        public DeContext(DbContextOptions options) : base(options)
        {
            
            Database.EnsureCreated();
        }



    }
}
