using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Challenge.Application.Handlers;
using Challenge.Application.Models;

namespace Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedaController : ControllerBase
    {
        private readonly IMediator mediator;

        public BusquedaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemModel>>> Get(string termino)
        {
            var request = new ObtenerItemRequest(termino);
            var result = await mediator.Send(request);

            return Ok(result);
        }

    }
}
