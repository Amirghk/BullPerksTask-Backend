using BullPerksTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BullPerksTask.Infrastructure.Persistence.Db.EntityConfigs;

public class TokenEntityConfigs : IEntityTypeConfiguration<Token>
{
    public void Configure(EntityTypeBuilder<Token> builder)
    {
        builder.HasKey(p  => p.Id);

        builder.Property(p => p.Id).ValueGeneratedOnAdd();

        builder.Property(p => p.Name).HasMaxLength(200);

        builder.ToTable("Tokens", "dbo");
    }
}
