using AdessoWL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdessoWL.Persistence.EntityTypeConfigurations;

public class TeamEntityTypeConfiguration : IEntityTypeConfiguration<TeamEntity>
{
    public void Configure(EntityTypeBuilder<TeamEntity> builder)
    {
        builder.ToTable("Teams");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();
        builder.Property(i => i.Name).IsRequired().HasMaxLength(100);
    }
}


