using MediatR;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Challenge.Application.Models;
using Challenge.Application.Handlers;

namespace Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly IMediator mediator;

        public PaisesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisModel>>> Get([FromRoute] string id)
        {
            var request = new ObtenerPaisRequest(id);
            var result = await mediator.Send(request);

            return Ok(result);
        }

    }

}
