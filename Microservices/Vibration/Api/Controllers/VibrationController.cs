using System;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos;
using Business.Services.Commands.AddVibrationRecord;
using Business.Services.Queries.GetAllVibrationRecords;
using Business.Services.Queries.GetUserVibrationRecords;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/v1/vibration")]
    public class VibrationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public VibrationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllVibrationRecordsQuery();

            var rawResults = await _mediator.Send(query);

            var results = _mapper.Map<GetAllVibrationRecordsDto>(rawResults);

            return Ok(results);
        }

        [HttpGet("{userid}")]
        public async Task<IActionResult> GetByUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest();
            }

            var query = new GetUserVibrationRecordsQuery(userId);

            var rawResults = await _mediator.Send(query);

            var results = _mapper.Map<GetUserVibrationRecordsDto>(rawResults);

            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddVibrationRecordDto record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = _mapper.Map<AddVibrationRecordCommand>(record);

            var result = await _mediator.Send(command);

            var createdRecordId = result.Id;

            return Created("api/v1/vibration/" + createdRecordId, createdRecordId);
        }
    }
}
