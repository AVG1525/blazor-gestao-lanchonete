using Microsoft.EntityFrameworkCore;

namespace BlazorMovie.Shared.Model.ModelBuilderExtensions
{
    public static class DataSeeding
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProductDescriptionOA>().HasData(
            //    new ProductDescriptionOA { Description = "BEBIDA" });
            //modelBuilder.Entity<ProductDescriptionOA>().HasData(
            //    new ProductDescriptionOA { Description = "LANCHE" });
            
            //modelBuilder.Entity<ProductPurchaseStatusOA>().HasData(
            //    new ProductPurchaseStatusOA { Description = "AGUARDE" });
            //modelBuilder.Entity<ProductPurchaseStatusOA>().HasData(
            //    new ProductPurchaseStatusOA { Description = "CONFIRMADO" });
        }
    }
}
