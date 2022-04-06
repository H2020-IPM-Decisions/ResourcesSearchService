using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace H2020.IPMDecisions.SCH.API.Models
{
    // This class matches the schema definition of /api/dss/rest/schema/dss
    public class DssInformation
    {
        public string Id { get; set; }
        public string Version { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<string> Languages { get; set; }
        [JsonPropertyName("organization")]
        public DssOrganization DssOrganization { get; set; }
        [JsonPropertyName("models")]
        public IEnumerable<DssModelInformation> DssModelInformation { get; set; }
    }

    public class DssOrganization
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
    }

    public class DssModelInformation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("type_of_decision")]
        public string TypeOfDecision { get; set; }
        [JsonPropertyName("type_of_output")]
        public string TypeOfOutput { get; set; }
        [JsonPropertyName("description_URL")]
        public string DescriptionUrl { get; set; }
        [JsonPropertyName("description")]
        public DssDescription Description { get; set; }
        public string Version { get; set; }
        // public string Citation { get; set; }
        public string Keywords { get; set; }
        public IEnumerable<string> Pests { get; set; }
        public IEnumerable<string> Crops { get; set; }
        [JsonPropertyName("valid_spatial")]
        public DssModelValidSpatial ValidSpatial { get; set; }
        public IEnumerable<DssModelAuthors> Authors { get; set; }
        [JsonPropertyName("platform_validated")]
        public bool PlatformValidated { get; set; }
    }

    public class DssDescription
    {
        [JsonPropertyName("created_by")]
        public string CreatedBy { get; set; }
        public string Age { get; set; }
        public string Assumptions { get; set; }
        [JsonPropertyName("peer_review")]
        public string PeerReview { get; set; }
        public string Other { get; set; }
    }

    public class DssModelValidSpatial
    {
        public IEnumerable<string> Countries { get; set; }
        public string GeoJson { get; set; }
    }

    public class DssModelAuthors
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
    }
}