using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Challenge.Nubi.Application.Handlers;
using System.Threading.Tasks;

namespace Challenge.Nubi.API.Controllers
{
    [ApiController]
    [Route("Example/[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly ILogger<ExampleController> logger;
        private readonly IMediator mediator;

        public ExampleController(ILogger<ExampleController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Application.Models.ExampleModel>> Get(Application.Models.Requests.ExampleModel body)
        {
            logger.LogInformation("Iniciando: {endponitName}.Get(param: {param})", nameof(ExampleController), body.ExampleProperty);

            var result = await mediator.Send(new ExampleApiHandlerRequest(body));

            return Ok(result);
        }
    }
}
