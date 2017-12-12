using System;
using Business.Dtos;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/temperature")]
    public class TemperatureController : Controller
    {
        private readonly ITemperatureService _temperatureService;

        public TemperatureController(ITemperatureService temperatureService)
        {
            _temperatureService = temperatureService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var results = _temperatureService.GetAllTemperatureRecords();

            return Ok(results);
        }

        [HttpGet("{userid}")]
        public IActionResult GetByUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest();
            }

            var result = _temperatureService.GetUserTemperatureRecords(userId);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddTemperatureRecordDto record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = _temperatureService.AddTemperatureRecord(record);

            return Created("api/v1/temperature/" + id, id);
        }
    }
}
