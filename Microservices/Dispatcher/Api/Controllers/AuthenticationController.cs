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
            LastCall.lastCall = DateTime.Now;
            SHA256 hash = SHA256.Create();
            UserRecord record = new UserRecord
            {
                UserName = model.UserName,
                PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(model.Password)),
                UserJwt = _repository.GenerateToken(),
                ExpireDateTime = DateTime.Now.AddMinutes(30)
            };

            var result = _repository.AddUser(record);

            if (result == null)
                return BadRequest();

            String payload = result.Entity.Id + "+" + result.Entity.UserJwt;
            return Created("api/authenticate/" + payload, payload);
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginUserRecordModel model)
        {
            LastCall.lastCall = DateTime.Now;
            SHA256 hash = SHA256.Create();
            UserRecord record = new UserRecord
            {
                UserName = model.UserName,
                PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(model.Password))
            };

            if (!_repository.CredentialsCheck(record))
                return BadRequest();

            var result = _repository.GetUserByName(model.UserName);
            return Ok(result.Id + "+" + result.UserJwt);
        }

        [HttpGet("{jwt}")]
        public IActionResult TokenValidation(String jwt)
        {
    
            if (!_repository.ValidToken(jwt, DateTime.Now,LastCall.lastCall))
                return BadRequest();
            return Ok();
        }
        
    }
}
