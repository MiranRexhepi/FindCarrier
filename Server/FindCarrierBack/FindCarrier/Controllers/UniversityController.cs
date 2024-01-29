using FindCarrier.Commands.Universities;
using FindCarrier.Domain.Entities;
using FindCarrier.HttpRequests;
using FindCarrier.Queries.Universities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindCarrier.Controllers
{
    [Authorize]
    [Route("api/universities")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UniversityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> UniversitiesList()
        {
            return Ok(await _mediator.Send(new GetUniversities.Query { }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<University>> GetUniversity(int id)  
        {
            var uni = await _mediator.Send(new GetUniversity.Query 
            {
                Id = id
            });

            if (uni == null)
                return NotFound();

            return Ok(uni);
        }

        [HttpGet("by-location")]
        public async Task<ActionResult<IEnumerable<University>>> Search([FromQuery] string location)
        {
            return Ok(await _mediator.Send(new GetUniversitiesByLocation.Query
            {
                Location = location
            }));
        }


        [HttpPost]
        public async Task<IActionResult> CreateUniversity([FromBody] AddOrCreateUniversityRequest university)
        {
            if (university == null)
                return BadRequest();
            
            return Ok(await _mediator.Send(new CreateUniversity.Command
            {
                University = university 
            }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUniversity([FromBody] AddOrCreateUniversityRequest university)
        {
            if(university == null)
                return BadRequest();

            return Ok(await _mediator.Send(new UpdateUniversity.Command
            {
                University = university
            }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversity(int id)
        {
            return Ok(await _mediator.Send(new DeleteUniversity.Command 
            {
                Id = id
            }));
        }
    }
} 