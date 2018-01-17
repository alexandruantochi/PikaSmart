using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence;

namespace Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public AuthenticationRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public EntityEntry<UserRecord> AddUser(UserRecord record)
        {
            var result  = _databaseContext.UserRecords.Add(record);
            _databaseContext.SaveChanges();
            return result;
        }

        public bool CredentialsCheck(UserRecord record)
        {
            UserRecord dbRecord = _databaseContext.UserRecords.FirstOrDefault(user => user.UserName == record.UserName);

            if (dbRecord == null)
                return false;

            return record.PasswordHash.SequenceEqual(dbRecord.PasswordHash);
        }

        public bool ValidToken(Byte[] jwt, DateTime reqTime)
        {
            var exprTime = _databaseContext.UserRecords.FirstOrDefault(token => token.PasswordHash.SequenceEqual(jwt));

            if (exprTime == null || exprTime.ExpireDateTime.CompareTo(reqTime) < 0)
                return false;
            return true;

        }

        public EntityEntry<UserRecord> EditUser(UserRecord record)
        {
            var result = _databaseContext.UserRecords.Update(record);
            _databaseContext.SaveChanges();
            return result;
        }
        
    }
}
