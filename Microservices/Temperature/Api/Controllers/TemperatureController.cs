using System;
using Business.Dtos;
using Business.Services;
using EnsureThat;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/temperature")]
    public class TemperatureController : Controller
    {
        private readonly ITemperatureServices _temperatureServices;

        public TemperatureController(ITemperatureServices temperatureServices)
        {
            _temperatureServices = temperatureServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var results = _temperatureServices.GetAllTemperatureRecords();

            return Ok(results);
        }

        [HttpGet("{userid}")]
        public IActionResult GetByUser(Guid userid)
        {
            EnsureArg.IsNotEmpty(userid);

            var result = _temperatureServices.GetTemperatureRecord(userid);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddTemperatureRecordDto record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _temperatureServices.AddTemperatureRecord(record);

            return NoContent();
        }
    }
}
