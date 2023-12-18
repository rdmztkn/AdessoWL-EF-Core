using AdessoWL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdessoWL.Persistence.EntityTypeConfigurations;

public class DrawTeamsEntityTypeConfiguration : IEntityTypeConfiguration<DrawTeamsEntity>
{
    public void Configure(EntityTypeBuilder<DrawTeamsEntity> builder)
    {
        builder.ToTable("Draw_Teams");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();

        builder.HasOne(i => i.TeamEntity)
            .WithMany(i => i.DrawTeams)
            .HasForeignKey(i => i.TeamId);

        builder.HasOne(i => i.DrawGroupsEntity)
            .WithMany(i => i.DrawTeams)
            .HasForeignKey(i => i.GroupId);
    }
}


