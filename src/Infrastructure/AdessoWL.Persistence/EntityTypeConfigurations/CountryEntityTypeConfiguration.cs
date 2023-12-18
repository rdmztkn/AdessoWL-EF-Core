using AdessoWL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdessoWL.Persistence.EntityTypeConfigurations;

public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<CountryEntity>
{
    public void Configure(EntityTypeBuilder<CountryEntity> builder)
    {
        builder.ToTable("Countries");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();
        builder.Property(i => i.Name).IsRequired().HasMaxLength(100);

        builder
            .HasMany(i => i.Teams)
            .WithOne(i => i.Country)
            .HasForeignKey(i => i.CountryId);
    }
}


