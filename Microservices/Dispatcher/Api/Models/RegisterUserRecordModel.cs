using System;

namespace Api.Models
{
    public class RegisterUserRecordModel
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public String UserJwt { get; set; }
    }
}
