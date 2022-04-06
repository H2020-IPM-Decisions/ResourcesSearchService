using System.Text.Json.Serialization;

namespace H2020.IPMDecisions.SCH.API.Dtos
{
    public class SearchResponseDto
    {
        [JsonPropertyName("resourceId")] 
        public string ResourceId { get; set; }
        [JsonPropertyName("title")] 
        public string Title { get; set; }
        [JsonPropertyName("resource_type")]
        public string ResourceType { get; set; }
        [JsonPropertyName("country_origin")]
        public string CountryOrigin { get; set; }
        [JsonPropertyName("language")]
        public string Language { get; set; }
        [JsonPropertyName("sector")]
        public string Sector { get; set; }
    }
}