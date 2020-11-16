using BlazorMovie.Shared.Model.OA;
using Microsoft.EntityFrameworkCore;

namespace BlazorMovie.Shared.Model.ModelBuilderExtensions
{
    public static class Relationship
    {
        public static void RelationshipMToN(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleOA>()
                .HasOne(pt => pt.UserOA)
                    .WithMany(p => p.SaleOA)
                        .HasForeignKey(pt => pt.UserOAId);

            modelBuilder.Entity<SaleOA>()
                .HasOne(pt => pt.ProductOA)
                    .WithMany(p => p.SaleOA)
                        .HasForeignKey(pt => pt.ProductOAId);

            modelBuilder.Entity<SaleOA>()
                .HasOne(pt => pt.ProductPurchaseStatusOA)
                    .WithMany(p => p.SaleOA)
                        .HasForeignKey(pt => pt.ProductPurchaseStatusOAId);
        }
    }
}
