using System;
using Api.ApiInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model.ApiDtos;

namespace Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/pressure")]
    public class PressureController : Controller
    {

        private readonly IPressureApi _pressureApi;

        public PressureController()
        {
            _pressureApi = new PressureApi("http://localhost:62714");
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var response = _pressureApi.ApiPressureGet();

            return Ok(response.Content);
        }

        [HttpGet("{userid}")]
        public IActionResult GetByUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest();
            }

            var response = _pressureApi.ApiPressureByUseridGet(userId);

            return Ok(response.Content);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddPressureRecordDto record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = _pressureApi.ApiPressurePost(record);

            return Ok(response.Content);
        }
    }
}
