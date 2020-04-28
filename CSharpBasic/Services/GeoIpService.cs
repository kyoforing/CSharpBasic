using CSharpBasic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            var ipData = JsonConvert.DeserializeObject<IpData>(message.Content.ReadAsStringAsync().Result);
            return ipData.Ip;
        }

        internal async Task<GeoDetail> GetGeoDetailAsync(string ip)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var strings = new string[] {ip};
            var content = JsonConvert.SerializeObject(strings);
            var stringContent = new StringContent(content);
            var message = await httpClient.PostAsync("http://ip-api.com/batch", stringContent);
            message.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<GeoDetail>>(message.Content.ReadAsStringAsync().Result).Single();
        }

        public async Task<GeoDetail> GetGeoDetailAsync()
        {
            var ip = await GetMyIpAsync();
            return await GetGeoDetailAsync(ip);
        }
    }
}