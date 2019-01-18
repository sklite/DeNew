using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeNew.Models.Entities;
using DeNew.Settings;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace DeNew.Models
{
    public class DeContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DeContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
