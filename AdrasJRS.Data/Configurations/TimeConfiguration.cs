﻿using AdrasJRS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdrasJRS.Data.Configurations;
public class TimeConfiguration : IEntityTypeConfiguration<Time>
{
    public void Configure(EntityTypeBuilder<Time> builder)
    {
        builder.ToTable("Times");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
        builder.Property(x => x.Slug).IsRequired();
        builder.Property(x => x.Disable).HasDefaultValue(false);
    }
}