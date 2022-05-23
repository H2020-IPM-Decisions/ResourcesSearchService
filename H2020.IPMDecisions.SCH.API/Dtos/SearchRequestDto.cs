using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace H2020.IPMDecisions.SCH.API.Dtos
{
    public class SearchRequestDto
    {
        [JsonPropertyName("regions")]
        public List<string> Regions { get; set; }
        [JsonPropertyName("pests")]
        public List<string> Pests { get; set; }
        [JsonPropertyName("crops")]
        public List<string> Crops { get; set; }
        [JsonPropertyName("language")]
        public string Language { get; set; }
    }
}