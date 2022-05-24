using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace H2020.IPMDecisions.SCH.API.Dtos
{
    public class SearchResponseDto
    {
        [JsonPropertyName("idResource")]
        public string ResourceId { get; set; }
        [JsonPropertyName("resourceName")]
        public string ResourceName { get; set; }

        [JsonPropertyName("regions")]
        public List<string> Regions { get; set; }
        [JsonPropertyName("languages")]
        public List<string> Languages { get; set; }

        [JsonPropertyName("resourceType")]
        public string ResourceType { get; set; } = "IPM Decisions Model";
        [JsonPropertyName("project")]
        public string Project { get; set; } = "IPM Decisions";
    }
}