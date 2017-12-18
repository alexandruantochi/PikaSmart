using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Maps
{
    class TemperatureRecordMap : IEntityTypeConfiguration<TemperatureRecord>
    {
        public void Configure(EntityTypeBuilder<TemperatureRecord> builder)
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