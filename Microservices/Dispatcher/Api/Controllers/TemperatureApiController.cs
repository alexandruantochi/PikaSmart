using System;
using Api.ApiInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model.ApiDtos;

namespace Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/temperature")]
    public class TemperatureController : Controller
    {

        private readonly ITemperatureApi _temperatureApi;

        public TemperatureController()
        {
            _temperatureApi = new TemperatureApi("http://localhost:62713");
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var response = _temperatureApi.ApiTemperatureGet();

            return Ok(response.Content);
        }

        [HttpGet("{userid}")]
        public IActionResult GetByUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest();
            }

            var response = _temperatureApi.ApiTemperatureByUseridGet(userId);

            return Ok(response.Content);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddTemperatureRecordDto record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = _temperatureApi.ApiTemperaturePost(record);

            return Ok(response.Content);
        }
    }
}
