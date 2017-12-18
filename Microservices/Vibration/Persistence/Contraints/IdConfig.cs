using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contraints
{
    class IdConfig: IEntityTypeConfiguration<VibrationRecord>
    {
        public void Configure(EntityTypeBuilder<VibrationRecord> builder)
        {
            //Set as primary key
            builder.HasKey(id => id.Id);

            builder.Property(id => id.Id)
                .HasColumnName("RecordId");
        }
    }
}
