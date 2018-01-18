using System;
using Api.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/v1/notification")]
    public class NotificationController : Controller
    {
        private readonly INotificationRepository _repository;

        public NotificationController(INotificationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetNotificationAll()
        {
            var result = _repository.GetNotificationAll();

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public IActionResult GetNotificationByUserId(Guid userId)
        {
            if(userId == Guid.Empty)
                return BadRequest();
                
            var result = _repository.GetNotificationByUserId(userId);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddNotification([FromBody] NotificationRecordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            NotificationRecord record = new NotificationRecord()
            {
                UserId = model.UserId,
                Date = model.Date,
                Text = model.Text
            };
            var result = _repository.AddNotification(record);

            var createdRecordId = result.Entity.Id;

            return Created("api/v1/notification/" + createdRecordId, createdRecordId);
           
        }
    }
}
