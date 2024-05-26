using AdrasJRS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdrasJRS.Data.Configurations;
public class CultureConfiguration : IEntityTypeConfiguration<Culture>
{
    public void Configure(EntityTypeBuilder<Culture> builder)
    {
        builder.ToTable("Cultures");
        builder.HasKey(x => x.Id);
    }
}