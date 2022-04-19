using System.Collections.Generic;
using System.Threading.Tasks;
using H2020.IPMDecisions.SCH.API.Models;

namespace H2020.IPMDecisions.SCH.API.Providers
{
    public interface IMicroservicesInternalCommunicationHttpProvider
    {
        Task<IEnumerable<DssInformation>> GetAllListOfDssFromDssMicroservice(string cropEppoCode, string language);
    }
}
