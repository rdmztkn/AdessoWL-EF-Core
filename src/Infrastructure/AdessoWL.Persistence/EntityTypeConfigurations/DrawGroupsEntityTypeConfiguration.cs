using AdessoWL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdessoWL.Persistence.EntityTypeConfigurations;

public class DrawGroupsEntityTypeConfiguration : IEntityTypeConfiguration<DrawGroupsEntity>
{
    public void Configure(EntityTypeBuilder<DrawGroupsEntity> builder)
    {
        builder.ToTable("Draw_Groups");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();
        builder.Property(i => i.GroupName).IsRequired().HasMaxLength(100);

        builder.HasOne(i => i.DrawEntity)
            .WithMany(i => i.DrawGroups)
            .HasForeignKey(i => i.DrawId);
    }
}


