using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;

namespace CSharpBasic.Models
{
    public interface IGeoIpService
    {
        Task<string> GetMyIpAsync();
        Task<GeoDetail> GetGeoDetailAsync(string ip);
        Task<GeoDetail> GetGeoDetailAsync();
    }
}