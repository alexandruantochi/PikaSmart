using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Maps
{
    sealed class VibrationRecordMap : IEntityTypeConfiguration<VibrationRecord>
    {
        public void Configure(EntityTypeBuilder<VibrationRecord> builder)
        {
            builder.HasKey(id => id.Id);

            builder.Property(id => id.Id)
                .HasColumnName("Id");

            builder.Property(time => time.Time)
                .IsRequired()
                .HasColumnName("Time");

            builder.Property(user => user.UserId)
                .IsRequired()
                .HasColumnName("UserId");

            builder.Property(val => val.Value)
                .IsRequired()
                .HasColumnName("Value");
        }
    }
}