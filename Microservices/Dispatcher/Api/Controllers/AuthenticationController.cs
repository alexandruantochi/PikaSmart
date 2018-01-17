using System;
using System.Security.Cryptography;
using System.Text;
using Api.Models;
using Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repositories;

namespace Api.Controllers
{
    [EnableCors("MyPolicy")]
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
            {   Id= new Guid(),
                UserName = model.UserName,
                PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(model.Password)),
                UserJwt = _repository.GenerateToken(),
                ExpireDateTime = DateTime.Now.AddMinutes(30)
            };

            var result = _repository.AddUser(record);

            if (result == null)
                return BadRequest();

            String payload = JsonConvert.SerializeObject(new JsonObject(){Id=result.Entity.Id,Token=result.Entity.UserJwt});
            return Ok( payload);
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
            String payload = JsonConvert.SerializeObject(new JsonObject() { Id = result.Id, Token = result.UserJwt });
            return Ok(payload);
        }

        [HttpGet("{jwt}")]
        public IActionResult TokenValidation(String jwt)
        {
    
            if (!_repository.ValidToken(jwt, DateTime.Now,LastCall.lastCall))
                return BadRequest();
            return Ok(new JsonObject());
        }
        
    }
}
