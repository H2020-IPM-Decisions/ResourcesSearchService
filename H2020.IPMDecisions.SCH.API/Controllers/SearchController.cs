﻿using H2020.IPMDecisions.SCH.API.Dtos;
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

        public SearchController(
            ILogger<SearchController> logger,
            IMicroservicesInternalCommunicationHttpProvider microservicesCommunication)
        {
            this.microservicesCommunication = microservicesCommunication;
            this.logger = logger;
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

                var listOfModels = listOfDss
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
                listOfDss = listOfDss
                    .ToList();
                // ToDo: map models to DSS to responseDto

                return Ok(listOfModels);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorMessageDto { Message = ex.Message });
            }
        }
    }
}