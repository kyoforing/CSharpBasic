using CSharpBasic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CSharpBasic.Services
{
    public class GeoIpService : IGeoIpService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GeoIpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        internal async Task<string> GetMyIpAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var message = await httpClient.GetAsync("https://api.ipify.org?format=json");
            message.EnsureSuccessStatusCode();
            var ipData = JsonSerializer.Deserialize<IpData>(await message.Content.ReadAsStringAsync());
            return ipData.Ip;
        }

        internal async Task<GeoDetail> GetGeoDetailAsync(string ip)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var strings = new string[] {ip};
            var content = JsonSerializer.Serialize(strings);
            var stringContent = new StringContent(content);
            var message = await httpClient.PostAsync("http://ip-api.com/batch", stringContent);
            message.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<List<GeoDetail>>(await message.Content.ReadAsStringAsync()).Single();
        }

        public async Task<GeoDetail> GetGeoDetailAsync()
        {
            var ip = await GetMyIpAsync();
            return await GetGeoDetailAsync(ip);
        }
    }
}