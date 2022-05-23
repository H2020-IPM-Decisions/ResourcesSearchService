using System.Text.Json.Serialization;

namespace H2020.IPMDecisions.SCH.API.Dtos
{
    public class SearchDetailedResponseDto
    {
        [JsonPropertyName("resourceId")]
        public string ResourceId { get; set; }
        [JsonPropertyName("resourceName")]
        public string ResourceName { get; set; }
        [JsonPropertyName("resourceType")]
        public string ResourceType { get; set; } = "IPM Decisions Model";
        [JsonPropertyName("regions")]
        public string Regions { get; set; }
        [JsonPropertyName("language")]
        public string Language { get; set; }
    }
}