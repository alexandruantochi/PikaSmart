using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public interface IDatabaseContext
    {
        DbSet<UserRecord> UserRecords { get; set; }

        int SaveChanges();
    }
}
