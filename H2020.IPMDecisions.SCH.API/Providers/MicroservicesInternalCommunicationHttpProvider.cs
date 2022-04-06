using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using H2020.IPMDecisions.SCH.API.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace H2020.IPMDecisions.SCH.API.Providers
{
    public class MicroservicesInternalCommunicationHttpProvider : IMicroservicesInternalCommunicationHttpProvider, IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration config;
        private readonly IMemoryCache memoryCache;

        public MicroservicesInternalCommunicationHttpProvider(
            HttpClient httpClient,
            IConfiguration config,
            IMemoryCache memoryCache)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.config = config ?? throw new ArgumentNullException(nameof(config));
            this.memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DssInformation>> GetAllListOfDssFromDssMicroservice()
        {
            throw new System.NotImplementedException();
        }
    }
}