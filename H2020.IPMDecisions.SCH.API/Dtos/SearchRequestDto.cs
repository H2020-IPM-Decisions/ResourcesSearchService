using System.Text.Json.Serialization;

namespace H2020.IPMDecisions.SCH.API.Dtos
{
    public class SearchRequestDto
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("sector")]
        public string Sector { get; set; }
        [JsonPropertyName("pest_type")]
        public string PestType { get; set; }
        [JsonPropertyName("resource_type")]
        public string ResourceType { get; set; }
        [JsonPropertyName("specific_crop")]
        public string SpecificCrop { get; set; }
        [JsonPropertyName("language")]
        public string Language { get; set; }
        [JsonPropertyName("project")]
        public string Project { get; set; }
    }
}