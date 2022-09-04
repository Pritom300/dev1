using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext: DbContext
    {
         public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Products> Products{get;set;}
        public DbSet<Warehouse> Warehouse{get;set;}

    }
}