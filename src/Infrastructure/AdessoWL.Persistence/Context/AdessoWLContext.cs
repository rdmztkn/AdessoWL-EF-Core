using AdessoWL.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdessoWL.Persistence.Context;

public class AdessoWLContext : DbContext
{
    public AdessoWLContext(DbContextOptions<AdessoWLContext> options) : base(options)
    {
    }

    public DbSet<CountryEntity> Countries { get; set; }
    public DbSet<TeamEntity> Teams { get; set; }
    public DbSet<DrawEntity> Draws { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdessoWLContext).Assembly);
    }
}
