using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contraints
{
    class ValueConfig: IEntityTypeConfiguration<TemperatureRecord>
    {
        public void Configure(EntityTypeBuilder<TemperatureRecord> builder)
        {
            builder.Property(val => val.Value)
                .IsRequired()
                .HasColumnName("Value");
        }
    }
}
