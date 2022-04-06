using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using H2020.IPMDecisions.SCH.API.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace H2020.IPMDecisions.SCH.API.Providers
{
    public class MicroservicesInternalCommunicationHttpProvider : IMicroservicesInternalCommunicationHttpProvider, IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration config;
        private readonly IMemoryCache memoryCache;
        private readonly ILogger<MicroservicesInternalCommunicationHttpProvider> logger;

        public MicroservicesInternalCommunicationHttpProvider(
            HttpClient httpClient,
            IConfiguration config,
            IMemoryCache memoryCache,
            ILogger<MicroservicesInternalCommunicationHttpProvider> logger)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.config = config ?? throw new ArgumentNullException(nameof(config));
            this.memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }

        public async Task<IEnumerable<DssInformation>> GetAllListOfDssFromDssMicroservice(string cropEppoCode, string language = "en")
        {
            try
            {
                var cacheKey = string.Format("listOfDss_{0}_{1}", cropEppoCode, language);
                if (!memoryCache.TryGetValue(cacheKey, out IEnumerable<DssInformation> listOfDss))
                {
                    var dssEndPoint = config["MicroserviceInternalCommunication:DssMicroservice"];
                    var response = await httpClient.GetAsync(string.Format("{0}rest/dss?language={1}", dssEndPoint, language));

                    if (!response.IsSuccessStatusCode)
                        return null;

                    var responseAsText = await response.Content.ReadAsStringAsync();
                    listOfDss = JsonSerializer.Deserialize<IEnumerable<DssInformation>>(responseAsText);

                    memoryCache.Set(
                        cacheKey,
                        listOfDss,
                        new MemoryCacheEntryOptions
                        {
                            AbsoluteExpiration = DateTime.Now.AddDays(1),
                            Priority = CacheItemPriority.Normal
                        });
                }
                return listOfDss;
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("Error in Internal Communication - GetAllListOfDssFromDssMicroservice. {0}", ex.Message));
                return null;
            }
        }
    }
}