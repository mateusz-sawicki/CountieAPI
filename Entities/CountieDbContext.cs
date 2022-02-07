using Microsoft.EntityFrameworkCore;


namespace CountieAPI.Entities
{
    public class CountieDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=CountieDb;Trusted_Connection=True;";
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Planner> Planners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Procedure>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Procedure>()
                .Property(r => r.Price)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<PlannerProcedure>()
                .HasKey(r => new {r.PlannerId, r.ProcedureId});

            modelBuilder.Entity<PlannerProcedure>()
                .HasOne<Procedure>(r => r.Procedure)
                .WithMany(p => p.Planners);

            modelBuilder.Entity<PlannerProcedure>()
                .HasOne<Planner>(r => r.Planner)
                .WithMany(p => p.Procedures);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
