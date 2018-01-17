using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Maps
{
    public class NotificationTemperatureMap : IEntityTypeConfiguration<NotificationRecord>
    {
        public void Configure(EntityTypeBuilder<NotificationRecord> builder)
        {
            builder.HasKey(obj => obj.Id);

            builder.Property(obj => obj.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(obj => obj.UserId)
                .IsRequired()
                .HasColumnName("UserId");

            builder.Property(obj => obj.Date)
                .IsRequired()
                .HasColumnName("Date");

            builder.Property(obj => obj.Text)
                .IsRequired()
                .HasColumnName("Text");
        }
    }
}
