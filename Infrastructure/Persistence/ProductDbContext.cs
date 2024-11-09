using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using static Domain.Entities.Product;


namespace Infrastructure.Persistence
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductReview> ProductReviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.RowVersion)
                .IsRowVersion(); // Configura RowVersion como control de concurrencia
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //Aquí se podrá configurar propiedades adicionales de las entidades.
        //    modelBuilder.Entity<Product>().HasKey(p => p.Id);
        //}
    }
}
