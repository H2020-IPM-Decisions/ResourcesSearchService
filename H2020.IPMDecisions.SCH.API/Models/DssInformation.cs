using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace H2020.IPMDecisions.SCH.API.Models
{
    // This class matches the schema definition of /api/dss/rest/schema/dss
    public class DssInformation
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("languages")]
        public List<string> Languages { get; set; }
        [JsonPropertyName("organization")]
        public DssOrganization DssOrganization { get; set; }
        [JsonPropertyName("models")]
        public IEnumerable<DssModelInformation> DssModelInformation { get; set; }
    }

    public class DssOrganization
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class DssModelInformation
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("type_of_decision")]
        public string TypeOfDecision { get; set; }
        [JsonPropertyName("type_of_output")]
        public string TypeOfOutput { get; set; }
        [JsonPropertyName("description_URL")]
        public string DescriptionUrl { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
        // public string Citation { get; set; }
        [JsonPropertyName("keywords")]
        public string Keywords { get; set; }
        [JsonPropertyName("pests")]
        public IEnumerable<string> Pests { get; set; }
        [JsonPropertyName("crops")]
        public IEnumerable<string> Crops { get; set; }
        [JsonPropertyName("valid_spatial")]
        public DssModelValidSpatial ValidSpatial { get; set; }
        [JsonPropertyName("authors")]
        public IEnumerable<DssModelAuthors> Authors { get; set; }
        [JsonPropertyName("platform_validated")]
        public bool PlatformValidated { get; set; }
    }

    public class DssModelValidSpatial
    {
        [JsonPropertyName("countries")]
        public IEnumerable<string> Countries { get; set; }
    }

    public class DssModelAuthors
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("organization")]
        public string Organization { get; set; }
    }
}