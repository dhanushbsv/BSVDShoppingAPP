using bsvd.shopping.application.Catalog.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace bsvd.shopping.application.Catalog.Data
{
    public class ShoppingDBContext : DbContext
    {
        public ShoppingDBContext() : base("ShoppingDBContext")
        {

        }


        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey<int>(s => s.CategoryId);
            modelBuilder.Entity<SubCategory>().HasKey<int>(s => s.SubCategoryId);
            modelBuilder.Entity<Product>().HasKey<int>(s => s.ProductId);

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Product>()
                .Property(n => n.Name)
                .IsRequired();

            modelBuilder.Entity<Product>()
               .Property(m => m.Model)
               .IsRequired();

            modelBuilder.Entity<Product>()
               .Property(s => s.SubCategoryId)
               .IsRequired();

            modelBuilder.Entity<Product>()
               .Property(p => p.Price)
               .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(n => n.Name)
                .IsRequired();

            modelBuilder.Entity<SubCategory>()
                .Property(n => n.Name)
                .IsRequired();

        }
    }
}