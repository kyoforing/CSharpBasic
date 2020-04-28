using Newtonsoft.Json;

namespace CSharpBasic.Models
{
    public class GeoDetail
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("regionName")]
        public string RegionName { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("zip")]
        public string ZipCode { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        [JsonProperty("isp")]
        public string Isp { get; set; }
        [JsonProperty("org")]
        public string Org { get; set; }
        [JsonProperty("as")]
        public string  As { get; set; }
        [JsonProperty("query")]
        public string QueriedIp { get; set; }
    }
}