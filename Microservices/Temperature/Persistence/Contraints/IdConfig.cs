using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contraints
{
    class IdConfig: IEntityTypeConfiguration<TemperatureRecord>
    {
        public void Configure(EntityTypeBuilder<TemperatureRecord> builder)
        {
            //Set as primary key
            builder.HasKey(id => id.Id);

            builder.Property(id => id.Id)
                .HasColumnName("RecordId");
        }
    }
}
