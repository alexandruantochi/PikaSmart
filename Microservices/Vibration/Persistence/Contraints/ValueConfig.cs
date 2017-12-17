using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contraints
{
    class ValueConfig: IEntityTypeConfiguration<VibrationRecord>
    {
        public void Configure(EntityTypeBuilder<VibrationRecord> builder)
        {
            builder.Property(val => val.Value)
                .IsRequired()
                .HasColumnName("Value");
        }
    }
}
