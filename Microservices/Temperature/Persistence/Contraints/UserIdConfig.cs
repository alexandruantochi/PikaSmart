using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contraints
{
    class UserIdConfig: IEntityTypeConfiguration<TemperatureRecord>
    {
        public void Configure(EntityTypeBuilder<TemperatureRecord> builder)
        {
            builder.Property(user => user.UserId)
                .IsRequired()
                .HasColumnName("UserId");
        }
    }
}
