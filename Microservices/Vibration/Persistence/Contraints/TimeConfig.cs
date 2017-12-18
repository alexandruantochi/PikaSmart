using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contraints
{
    class TimeConfig : IEntityTypeConfiguration<VibrationRecord>
    {
        public void Configure(EntityTypeBuilder<VibrationRecord> builder)
        {
            builder.Property(time => time.Time)
                .IsRequired()
                .HasColumnName("Time");
        }
    }
}
