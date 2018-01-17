﻿using System;
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
            _vibrationApi = new VibrationApi("http://localhost:62715");
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var response = _vibrationApi.ApiVibrationGet();

            return Ok(response.Content);
        }

        [HttpGet("{userid}")]
        public IActionResult GetByUser(Guid userId)
        {
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = _vibrationApi.ApiVibrationPost(record);

            return Ok(response.Content);
        }
    }
}
