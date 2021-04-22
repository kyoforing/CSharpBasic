using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CSharpBasic.Interface;
using CSharpBasic.Models;

namespace CSharpBasic.Service
{
    public class GeoIpService : IGeoIpService
    {
        private readonly HttpClient _httpClient;

        public GeoIpService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<WhereAmIResponse> GetGeoDataAsync()
        {
            var myIp = await GetMyIp();
            var myGeoData = await GetMyGeoData(myIp);
            return myGeoData;
        }

        private async Task<string> GetMyIp()
        {
            var message = await _httpClient.GetAsync("https://api.ipify.org?format=json");
            message.EnsureSuccessStatusCode();
            var ipData = JsonSerializer.Deserialize<IpData>(await message.Content.ReadAsStringAsync());

            return ipData.ip;
        }

        private async Task<WhereAmIResponse> GetMyGeoData(string myIp)
        {
            var message = await _httpClient.PostAsync("http://ip-api.com/batch", new StringContent($"[\"{myIp}\"]"));
            var geoDetail = JsonSerializer.Deserialize<List<GeoDetail>>(await message.Content.ReadAsStringAsync()).Single();

            return new WhereAmIResponse(myIp, geoDetail.countryCode);
        }
    }
}