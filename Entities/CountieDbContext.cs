using Microsoft.EntityFrameworkCore;


namespace CountieAPI.Entities
{
    public class CountieDbContext : DbContext
    {
        public CountieDbContext(DbContextOptions<CountieDbContext> options) : base(options)
        {

        }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Planner> Planners { get; set; }
        public DbSet<User>  Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(r => r.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Procedure>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Procedure>()
                .Property(r => r.Price)
                .IsRequired();


            modelBuilder.Entity<Category>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var connectionString = configuration.GetConnectionString("CountieDbConnection");
            optionsBuilder.UseSqlServer(connectionString);

        }
    }
}