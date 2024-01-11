using Zoo.Models;

namespace Zoo.Data
{
    public class DataContext : DbContext
    {
        public required DbSet<Enclosure> Enclosures { get; set; }
        public required DbSet<Animal> Animals { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Enclosure>(entity =>
            {
                entity.OwnsMany(e => e.Objects);

                entity.HasMany(e => e.Animals)
                    .WithOne(a => a.Enclosure)
                    .HasForeignKey(a => a.EnclosureId);
            });
        }
    }
}
