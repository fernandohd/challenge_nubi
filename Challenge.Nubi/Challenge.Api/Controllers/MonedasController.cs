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
    public class MonedasController : ControllerBase
    {
        private readonly IMediator mediator;

        public MonedasController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyModel>>> GetAll()
        {
            var request = new ObtenerMonedasRequest();
            var result = await mediator.Send(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IEnumerable<CurrencyModel>>> Get([FromRoute] string id)
        {
            var request = new ObtenerMonedaRequest(id);
            var result = await mediator.Send(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("conversion")]
        public async Task<ActionResult<ConversionModel>> Get([FromQuery] string from, [FromQuery] string to)
        {
            var request = new ObtenerConversionRequest(from, to);
            var result = await mediator.Send(request);

            return Ok(result);
        }
    }
}
