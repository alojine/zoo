using Microsoft.EntityFrameworkCore;
using Zoo.Models;

namespace Zoo.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Enclosure>? Enclosures { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Enclosure>(entity =>
            {
                entity.OwnsMany(t => t.Objects);
            });
        }
    }
}
