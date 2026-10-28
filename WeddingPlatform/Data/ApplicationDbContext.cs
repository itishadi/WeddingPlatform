using Microsoft.EntityFrameworkCore;
using WeddingPlatform.Models;

namespace WeddingPlatform.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<WeddingInfo> WeddingInfos { get; set; }
        public DbSet<WeddingImage> WeddingImages { get; set; }
    }
}