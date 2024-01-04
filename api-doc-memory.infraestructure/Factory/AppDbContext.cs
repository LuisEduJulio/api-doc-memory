using api_doc_memory.domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace api_doc_memory.infraestructure.Factory
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PersonEntity> PersonEntities { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<PersonEntity>().Property<bool>("IsTestEntity");

            modelBuilder.Entity<PersonEntity>().HasQueryFilter(e => EF.Property<bool>(e, "IsTestEntity") || !EF.Property<bool>(e, "IsTestEntity"));
        }
        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries<PersonEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property<bool>("IsTestEntity").CurrentValue = true;
                }
            }
        }
    }
}