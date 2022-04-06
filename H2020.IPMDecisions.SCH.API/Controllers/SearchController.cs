using H2020.IPMDecisions.SCH.API.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace H2020.IPMDecisions.SCH.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {

        private readonly ILogger<SearchController> _logger;

        public SearchController(ILogger<SearchController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Use this request to search for the IPM Decisions platform resources
        /// </summary>
        /// </remarks>
        [ProducesResponseType(typeof(IEnumerable<SearchResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpPost(Name = "api.search.post")]
        public async Task<IActionResult> Post([FromBody] SearchRequestDto searchRequestDto)
        {
            return Ok();
        }
    }
}
