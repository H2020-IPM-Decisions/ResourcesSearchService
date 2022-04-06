using System.Text.Json.Serialization;

namespace H2020.IPMDecisions.SCH.API.Dtos
{
    public class SearchResponseDto
    {
        public string ResourceId { get; set; }
        public string Title { get; set; }
        [JsonPropertyName("resource_type")]
        public string ResourceType { get; set; }
        [JsonPropertyName("country_origin")]
        public string CountryOrigin { get; set; }
        public string Language { get; set; }
        public string Sector { get; set; }
    }
}