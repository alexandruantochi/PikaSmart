using System;
using Api.ApiInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model.ApiDtos;

namespace Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/vibration")]
    public class VibrationController : Controller
    {

        private readonly IVibrationApi _vibrationApi;

        public VibrationController()
        {
            _vibrationApi = new VibrationApi("http://localhost:61714");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            LastCall.lastCall = DateTime.Now;
            var response = _vibrationApi.ApiVibrationGet();

            return Ok(response.Content);
        }

        [HttpGet("{userid}")]
        public IActionResult GetByUser(Guid userId)
        {
            LastCall.lastCall = DateTime.Now;
            if (userId == Guid.Empty)
            {
                return BadRequest();
            }

            var response = _vibrationApi.ApiVibrationByUseridGet(userId);

            return Ok(response.Content);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddVibrationRecordDto record)
        {
            LastCall.lastCall = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = _vibrationApi.ApiVibrationPost(record);

            return Ok(response.Content);
        }
    }
}
