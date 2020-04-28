using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;

namespace CSharpBasic.Models
{
    public interface IGeoIpService
    {
        Task<string> GetMyIp();
        Task<GeoDetail> GetGeoDetailAsync(string ip);
        Task<GeoDetail> GetGeoDetailAsync();
    }
}