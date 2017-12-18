using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contraints
{
    class UserIdConfig: IEntityTypeConfiguration<VibrationRecord>
    {
        public void Configure(EntityTypeBuilder<VibrationRecord> builder)
        {
            builder.Property(user => user.UserId)
                .IsRequired()
                .HasColumnName("UserId");
        }
    }
}
