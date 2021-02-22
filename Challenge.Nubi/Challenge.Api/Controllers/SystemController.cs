using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        [HttpGet]
        [Route("version")]
        public async Task<ActionResult<string>> GetVersion()
        {
            await Task.CompletedTask;

            return Ok(Environment.Version.ToString());
        }
    }
}