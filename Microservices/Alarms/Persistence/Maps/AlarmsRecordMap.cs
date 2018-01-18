using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Maps
{
    sealed class AlarmsRecordMap : IEntityTypeConfiguration<AlarmsRecord>
    {
        public void Configure(EntityTypeBuilder<AlarmsRecord> builder)
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