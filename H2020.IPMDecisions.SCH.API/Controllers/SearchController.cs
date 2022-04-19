using AutoMapper;
using H2020.IPMDecisions.SCH.API.Dtos;
using H2020.IPMDecisions.SCH.API.Models;
using H2020.IPMDecisions.SCH.API.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace H2020.IPMDecisions.SCH.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {

        private readonly ILogger<SearchController> logger;
        private readonly IMicroservicesInternalCommunicationHttpProvider microservicesCommunication;
        private readonly IMapper mapper;

        public SearchController(
            ILogger<SearchController> logger,
            IMicroservicesInternalCommunicationHttpProvider microservicesCommunication,
            IMapper mapper)
        {
            this.microservicesCommunication = microservicesCommunication ?? throw new ArgumentNullException(nameof(microservicesCommunication));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Use this request to search for the IPM Decisions platform resources
        /// </summary>
        /// </remarks>
        [ProducesResponseType(typeof(IEnumerable<SearchResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessageDto), StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpPost(Name = "api.search.post")]
        public async Task<IActionResult> Post([FromBody] SearchRequestDto searchRequestDto)
        {
            try
            {
                var listOfDss = await this.microservicesCommunication.GetAllListOfDssFromDssMicroservice(searchRequestDto.SpecificCrop, searchRequestDto.Language);
                if (listOfDss == null) throw new SystemException("System not available, please try again later.");

                IEnumerable<DssModelInformation> listOfModels = listOfDss
                    .SelectMany(d => d.DssModelInformation);
                if (!string.IsNullOrEmpty(searchRequestDto.PestType))
                {
                    listOfModels = listOfModels
                        .Where(m => m.Pests
                            .Contains(searchRequestDto.PestType.ToUpper()));
                }
                // if (!string.IsNullOrEmpty(searchRequestDto.Country)){}
                // if (!string.IsNullOrEmpty(searchRequestDto.Sector)){}
                // if (!string.IsNullOrEmpty(searchRequestDto.ResourceType)){}

                listOfModels = listOfModels
                    .ToList();
                var dataToReturn = this.mapper.Map<IEnumerable<SearchResponseDto>>(listOfModels);
                return Ok(dataToReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorMessageDto { Message = ex.Message });
            }
        }
    }
}