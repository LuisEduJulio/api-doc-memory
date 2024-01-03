using api_doc_memory.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_doc_memory.infraestructure.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder
                .ToTable("Person");
            builder
                .HasKey(p => p.Id);
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(p => p.Name)
                .IsRequired();
            builder
                .Property(p => p.Age)
                .IsRequired();
        }
    }
}