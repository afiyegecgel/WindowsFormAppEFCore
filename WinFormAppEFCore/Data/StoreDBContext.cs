using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WinFormAppEFCore.Models;

namespace WinFormAppEFCore.Data
{
    class StoreDBContext : DbContext
    {
        public StoreDBContext()
        {

        }
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This model can be created by using Products.
            modelBuilder.Entity<Categories>()
                        .HasMany(x => x.Products)
                        .WithOne(x => x.Category)
                        .HasForeignKey(x => x.CategoryId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLOCALDB; Database=Store; Integrated Security=true");
            }
        }
    }
}
