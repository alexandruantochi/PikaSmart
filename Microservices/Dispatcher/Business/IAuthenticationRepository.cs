using System;
using Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repositories
{
    public interface IAuthenticationRepository
    {
        EntityEntry<UserRecord> AddUser(UserRecord record);
        EntityEntry<UserRecord> EditUser(UserRecord record);
        bool CredentialsCheck(UserRecord record);
        bool ValidToken(Byte[] jwt, DateTime reqTime);
    }
}
