using System;
using System.Linq;
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
            if (GetUserByName(record.UserName) == null)
            {
                var result = _databaseContext.UserRecords.Add(record);

                _databaseContext.SaveChanges();
                return result;
            }
            return null;
        }
        

        public bool CredentialsCheck(UserRecord record)
        {
            UserRecord dbRecord = _databaseContext.UserRecords.FirstOrDefault(user => user.UserName == record.UserName);

            if (dbRecord == null)
                return false;

            return record.PasswordHash.SequenceEqual(dbRecord.PasswordHash);
        }

        public bool ValidToken(String jwt, DateTime reqTime,DateTime lastCall)
        {
            var exprTime = _databaseContext.UserRecords.FirstOrDefault(token => token.UserJwt == jwt);

            //if user doesn't make any calls
            if (lastCall.AddMinutes(30).CompareTo(DateTime.Now) < 0 || lastCall.CompareTo(DateTime.Now) > 0)
                return false;
            //token exists
            if (exprTime != null)
            {
                //if expiered, change token
                if (exprTime.ExpireDateTime.CompareTo(reqTime) < 0)
                    RenewToken(jwt);
                
                return true;
            }
            return false;

        }

        public EntityEntry<UserRecord> EditUser(UserRecord record)
        {
            var result = _databaseContext.UserRecords.Update(record);
            _databaseContext.SaveChanges();
            return result;
        }

        public void RenewToken(string jwt)
        {
            var entry = _databaseContext.UserRecords.FirstOrDefault(token => token.UserJwt == jwt);

            if (entry != null && DateTime.Now.CompareTo(entry.ExpireDateTime) < 0)
            {
                 entry.ExpireDateTime = DateTime.Now.AddMinutes(30);
                 entry.UserJwt = GenerateToken();
                _databaseContext.UserRecords.Update(entry);
                _databaseContext.SaveChanges();
            }
        }

        public String GenerateToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            return Convert.ToBase64String(time.Concat(key).ToArray());
        }

        public UserRecord GetUserByName(String userName)
        {
            return _databaseContext.UserRecords.FirstOrDefault(user => user.UserName == userName);
            
        }
    }
}

