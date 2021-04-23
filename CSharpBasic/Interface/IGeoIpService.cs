using System.Threading.Tasks;
using CSharpBasic.Models;

namespace CSharpBasic.Interface
{
    public interface IGeoIpService
    {
        Task<WhereAmIResponse> GetGeoDataAsync();
    }
}