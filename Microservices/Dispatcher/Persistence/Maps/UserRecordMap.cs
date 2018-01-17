using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Maps
{
    sealed class UserRecordMap : IEntityTypeConfiguration<UserRecord>
    {
        public void Configure(EntityTypeBuilder<UserRecord> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(user => user.UserName)
                .IsRequired()
                .HasColumnName("User");

            builder.Property(user => user.PasswordHash)
                .IsRequired()
                .HasColumnName("Password");

            builder.Property(jwt => jwt.UserJwt)
                .IsRequired()
                .HasColumnName("Token");

            builder.Property(expr => expr.ExpireDateTime)
                .IsRequired()
                .HasColumnName("Expiration");
        }
    }
}
