using System;
using Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repositories
{
    public interface IAuthenticationRepository
    {
        EntityEntry<UserRecord> AddUser(UserRecord record);
        EntityEntry<UserRecord> EditUser(UserRecord record);
        UserRecord GetUserByName(String userName);
        bool CredentialsCheck(UserRecord record);
        bool ValidToken(String jwt, DateTime reqTime,DateTime lasCall);
        String GenerateToken();
        void RenewToken(String jwt);
    }
}
