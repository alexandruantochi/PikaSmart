using System;
using Business.Dtos;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/vibration")]
    public class VibrationController : Controller
    {
        private readonly IVibrationService _vibrationService;

        public VibrationController(IVibrationService vibrationService)
        {
            _vibrationService = vibrationService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var results = _vibrationService.GetAllVibrationRecords();

            return Ok(results);
        }

        [HttpGet("{userid}")]
        public IActionResult GetByUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest();
            }

            var result = _vibrationService.GetUserVibrationRecords(userId);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddVibrationRecordDto record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = _vibrationService.AddVibrationRecord(record);

            return Created("api/v1/Vibration/" + id, id);
        }
    }
}
