using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using OData.Demo.Core.Features.Clients.Commands.CreateClient;
using OData.Demo.Core.Features.Clients.Queries.GetClientsList;

namespace OData.Demo.Api.Controllers
{
    public class ClientsController : ODataController
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var query = new GetClientsQuery { IncludeInactive = false };
            var result = await _mediator.Send(query);

            return Ok(result.Value);
        }

        [EnableQuery]
        public async Task<IActionResult> Get(int key)
        {
            var query = new GetClientByIdQuery { Id = key };
            var result = await _mediator.Send(query);

            if (result.Value == null)
                return NotFound();

            return Ok(result.Value);
        }

        public async Task<IActionResult> Post([FromBody] CreateClientCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Created(result.Value);
        }
    }
}