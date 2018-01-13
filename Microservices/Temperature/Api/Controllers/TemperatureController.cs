using System;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos;
using Business.Services.Commands.AddTemperatureRecord;
using Business.Services.Queries.GetAllTemperatureRecords;
using Business.Services.Queries.GetUserTemperatureRecords;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/v1/temperature")]
    public class TemperatureController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TemperatureController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllTemperatureRecordsQuery();

            var rawResults = await _mediator.Send(query);

            var results = _mapper.Map<GetAllTemperatureRecordsDto>(rawResults);

            return Ok(results);
        }

        [HttpGet("{userid}")]
        public async Task<IActionResult> GetByUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest();
            }

            var query = new GetUserTemperatureRecordsQuery(userId);

            var rawResults = await _mediator.Send(query);

            var results = _mapper.Map<GetUserTemperatureRecordsDto>(rawResults);

            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTemperatureRecordDto record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = _mapper.Map<AddTemperatureRecordCommand>(record);

            var result = await _mediator.Send(command);

            var createdRecordId = result.Id;

            return Created("api/v1/temperature/" + createdRecordId, createdRecordId);
        }
    }
}
