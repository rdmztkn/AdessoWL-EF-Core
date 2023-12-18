using AdessoWL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdessoWL.Persistence.EntityTypeConfigurations;

public class DrawEntityTypeConfiguration : IEntityTypeConfiguration<DrawEntity>
{
    public void Configure(EntityTypeBuilder<DrawEntity> builder)
    {
        builder.ToTable("Draws");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();
    }
}


