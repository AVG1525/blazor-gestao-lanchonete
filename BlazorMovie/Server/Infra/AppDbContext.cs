using BlazorMovie.Shared.Model;
using BlazorMovie.Shared.Model.ModelBuilderExtensions;
using BlazorMovie.Shared.Model.OA;
using Microsoft.EntityFrameworkCore;

namespace BlazorMovie.Server.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base (options)
        { }

        public DbSet<RegisterModel> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        
        // OA
        public DbSet<UserOA> UserOA { get; set; }
        public DbSet<SaleOA> SaleOA { get; set; }
        public DbSet<ProductOA> ProductOA { get; set; }
        public DbSet<ProductDescriptionOA> ProductDescriptionOA { get; set; }
        public DbSet<ProductPurchaseStatusOA> ProductPurchaseStatusOA { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RelationshipMToN();
            modelBuilder.Seed();
        }
    }
}
