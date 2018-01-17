using System;

namespace Domain
{
    public class UserRecord
    {
        public Guid Id { get; set; }
        public String UserName { get; set; }
        public Byte[] PasswordHash { get; set; }
        public Byte[] UserJwt { get; set; }
        public DateTime ExpireDateTime { get; set; }

        public UserRecord()
        {
            Id = new Guid();
        }

    }
}
