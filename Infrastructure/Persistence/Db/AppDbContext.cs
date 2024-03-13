using BullPerksTask.Domain.Entities;
using BullPerksTask.Infrastructure.Persistence.Db.EntityConfigs;
using Microsoft.EntityFrameworkCore;

namespace BullPerksTask.Infrastructure.Persistence.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new TokenEntityConfigs());

    }
    public DbSet<Token> Tokens { get; set; }
}
