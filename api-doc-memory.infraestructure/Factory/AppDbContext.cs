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
        public DbSet<PersonEntity> PersonEntitys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}