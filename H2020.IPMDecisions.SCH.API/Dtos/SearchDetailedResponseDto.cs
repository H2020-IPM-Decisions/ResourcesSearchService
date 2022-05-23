using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace H2020.IPMDecisions.SCH.API.Dtos
{
    public class SearchDetailedResponseDto
    {
        [JsonPropertyName("resourceId")]
        public string ResourceId { get; set; }
        [JsonPropertyName("resourceOrigin")]
        public string ResourceOrigin { get; set; }
        [JsonPropertyName("resourceName")]
        public string ResourceName { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("resourceType")]
        public string ResourceType { get; set; } = "IPM Decisions Model";
        [JsonPropertyName("contactInstitution")]
        public string ContactInstitution { get; set; }
        [JsonPropertyName("contactEmail")]
        public string ContactEmail { get; set; }
        [JsonPropertyName("contactPhone")]
        public string ContactPhone { get; set; }
        [JsonPropertyName("links")]
        public string Links { get; set; }
        [JsonPropertyName("project")]
        public string Project { get; set; } = "IPM Decisions";
        [JsonPropertyName("citation")]
        public string Citation { get; set; }
        [JsonPropertyName("pests")]
        public List<string> Pests { get; set; }
        [JsonPropertyName("crops")]
        public List<string> Crops { get; set; }
        [JsonPropertyName("regions")]
        public string Regions { get; set; }
        [JsonPropertyName("languages")]
        public List<string> Languages { get; set; }
    }
}