using System;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos;
using Business.Services.Commands.AddPressureRecord;
using Business.Services.Queries.GetAllPressureRecords;
using Business.Services.Queries.GetUserPressureRecords;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/v1/pressure")]
    public class PressureController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PressureController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPressureRecordsQuery();

            var rawResults = await _mediator.Send(query);

            var results = _mapper.Map<GetAllPressureRecordsDto>(rawResults);

            return Ok(results);
        }

        [HttpGet("{userid}")]
        public async Task<IActionResult> GetByUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest();
            }

            var query = new GetUserPressureRecordsQuery(userId);

            var rawResults = await _mediator.Send(query);

            var results = _mapper.Map<GetUserPressureRecordsDto>(rawResults);

            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPressureRecordDto record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = _mapper.Map<AddPressureRecordCommand>(record);

            var result = await _mediator.Send(command);

            var createdRecordId = result.Id;

            return Created("api/v1/pressure/" + createdRecordId, createdRecordId);
        }
    }
}
