using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;

namespace CSharpBasic.Models
{
    public interface IGeoIpService
    {
        Task<GeoDetail> GetGeoDetailAsync();
    }
}