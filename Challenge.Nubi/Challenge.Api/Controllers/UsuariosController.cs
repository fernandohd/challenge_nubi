using MediatR;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Challenge.Application.Handlers;
using Challenge.Application.Models;

namespace Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsuariosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAll()
        {
            var request = new ObtenerUsuariosRequest();
            var result = await mediator.Send(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<UserModel>> Get([FromRoute] int id)
        {
            var request = new ObtenerUsuarioRequest(id);
            var result = await mediator.Send(request);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserModel user)
        {
            var request = new InsertarUsuarioRequest(user);
            await mediator.Send(request);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserModel user)
        {
            var request = new ActualizarUsuarioRequest(user);
            await mediator.Send(request);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var request = new EliminarUsuarioRequest(id);
            await mediator.Send(request);

            return Ok();
        }
    }
}
