using Microsoft.EntityFrameworkCore;

namespace BlazorMovie.Shared.Model.ModelBuilderExtensions
{
    public static class DataSeeding
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Post>().HasData(
            //    new { BlogId = 1, PostId = 2, Title = "Second post", Content = "Test 2" });
        }
    }
}
