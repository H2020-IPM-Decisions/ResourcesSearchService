using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace H2020.IPMDecisions.SCH.API.Controllers
{
    /// <summary>
    /// Root endpoint for the microservice.
    /// </summary>
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/api")]
    [ApiController]
    public class RootController : ControllerBase
    {
        /// <summary>
        /// This request gets the main endpoint from the API.
        /// </summary>
        [HttpGet("", Name = "api.root")]
        public IActionResult GetRoot()
        {
            return Ok();
        }
    }
}
