using System.Text.Json.Serialization;

namespace CSharpBasic.Models
{
    public class IpData
    {
        [JsonPropertyName("ip")]
        public string Ip { get; set; }
    }
}