using Microsoft.EntityFrameworkCore;


namespace CountieAPI.Entities
{
    public class CountieDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=CountieDb;Trusted_Connection=True;";
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(35);

            modelBuilder.Entity<Procedure>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Procedure>()
                .Property(r => r.Price)
                .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
