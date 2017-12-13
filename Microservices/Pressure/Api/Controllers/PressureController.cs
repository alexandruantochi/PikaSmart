using System;
using Business.Dtos.Atomic;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/pressure")]
    public class PressureController : Controller
    {
        private readonly IPressureService _pressureService;

        public PressureController(IPressureService pressureService)
        {
            _pressureService = pressureService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var results = _pressureService.GetAllPressureRecords();

            return Ok(results);
        }

        [HttpGet("{userid}")]
        public IActionResult GetByUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest();
            }

            var result = _pressureService.GetUserPressureRecords(userId);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddPressureRecordDto record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = _pressureService.AddPressureRecord(record);

            return Created("api/v1/pressure/" + id, id);
        }
    }
}
