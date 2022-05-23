﻿using AutoMapper;
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
                var listOfCrops = searchRequestDto.Crops != null ? string.Join(",", searchRequestDto.Crops).ToUpper() : "";
                var listOfDss = await this.microservicesCommunication.GetAllListOfDssFromDssMicroservice(listOfCrops, searchRequestDto.Language);
                if (listOfDss == null) throw new SystemException("System not available, please try again later.");

                IEnumerable<DssInformationJoined> dssModelsWithParent = listOfDss
                    .SelectMany(d => d.DssModelInformation, (dss, model) =>
                        new DssInformationJoined { DssInformation = dss, DssModelInformation = model });

                if (searchRequestDto.Pests != null & searchRequestDto.Pests.Count > 0)
                {
                    var pests = searchRequestDto.Pests.Select(p => p.ToUpper());
                    dssModelsWithParent = dssModelsWithParent
                        .Where(m => m.DssModelInformation.Pests != null)
                        .Where(m => m.DssModelInformation.Pests
                            .Intersect(pests)
                            .Any());
                }
                // if (!string.IsNullOrEmpty(searchRequestDto.Country)){}
                // if (!string.IsNullOrEmpty(searchRequestDto.Sector)){}
                // if (!string.IsNullOrEmpty(searchRequestDto.ResourceType)){}

                dssModelsWithParent = dssModelsWithParent
                    .ToList();
                var dataToReturn = this.mapper.Map<IEnumerable<SearchResponseDto>>(dssModelsWithParent);
                return Ok(dataToReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorMessageDto { Message = ex.Message });
            }
        }
    }
}