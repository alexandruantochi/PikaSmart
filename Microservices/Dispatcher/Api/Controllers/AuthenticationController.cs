using System;
using System.Security.Cryptography;
using System.Text;
using Api.Models;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace Api.Controllers
{
    [Route("api/authenticate")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationRepository _repository;

        public AuthenticationController(IAuthenticationRepository repository)
        {
            _repository = repository;
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] RegisterUserRecordModel model)
        {
            SHA256 hash = SHA256.Create();
            UserRecord record = new UserRecord();
            record.UserName = model.UserName;
            record.PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            record.UserJwt = hash.ComputeHash(Encoding.UTF8.GetBytes(model.UserJwt));
            record.ExpireDateTime = DateTime.Now.AddMinutes(30);

            var result = _repository.AddUser(record);

            if (result == null)
                return BadRequest();

            var createdRecordId = result.Entity.Id;
            return Created("api/authenticate/" + createdRecordId, createdRecordId);
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginUserRecordModel model)
        {
            SHA256 hash = SHA256.Create();
            UserRecord record = new UserRecord
            {
                UserName = model.UserName,
                PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(model.Password))
            };

            if (!_repository.CredentialsCheck(record))
                return BadRequest();
            return Ok();
        }

        [HttpGet]
        public IActionResult TokenValidation(string jwt)
        {
            SHA256 hash = SHA256.Create();           
            if (!_repository.ValidToken(hash.ComputeHash(Encoding.UTF8.GetBytes(jwt)), DateTime.Now))
                return BadRequest();
            return Ok();
        }
    }
}
