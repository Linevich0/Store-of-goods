using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Shop2.Models;

namespace Shop2.DAL
{
    public class ShopContext : DbContext
    {

        public ShopContext() : base("ShopContext")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<AddProductInfo> AddProductsInfo { get; set; }
        public DbSet<PackType> PackTypes { get; set; }
        public DbSet<ProductPackInfo> ProductsPackInfo { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Buyer> Buyer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}