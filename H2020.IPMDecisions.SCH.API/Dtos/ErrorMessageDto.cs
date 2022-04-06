using System.Text.Json.Serialization;

namespace H2020.IPMDecisions.SCH.API.Dtos
{
    public class ErrorMessageDto
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}