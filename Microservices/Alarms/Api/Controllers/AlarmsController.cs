using System;
using Business.Dtos;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using ArduinoLib;

namespace Api.Controllers
{
    [Route("api/v1/alarms")]
    public class AlarmsController : Controller
    {
        private readonly IAlarmsService _alarmsService;
        private IConnection conn = ArduinoConnection.Build();
       
        public AlarmsController(IAlarmsService alarmsService)
        {
            _alarmsService = alarmsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            conn.Write("10");
            var alarm = conn.Read();
            String result;

            switch (alarm)
            {
                case "0":
                    result = "no alarm";
                    break;
                case "1":
                    result = "Fire Alarm";
                    break;
                
                default:
                    result = "No alarms";
                    break;
            }
         

            return Ok(result);
        }

        [HttpGet("{userid}")]
        public IActionResult GetByUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest();
            }

            var result = _alarmsService.GetUserAlarmsRecords(userId);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddAlarmsRecordDto record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = _alarmsService.AddAlarmsRecord(record);

            return Created("api/v1/alarms/" + id, id);
        }
    }
}
