using System.Threading.Tasks;

namespace CSharpBasic.Models
{
    public interface IGeoIpService
    {
        Task<GeoDetail> GetGeoDetailAsync();
    }
}