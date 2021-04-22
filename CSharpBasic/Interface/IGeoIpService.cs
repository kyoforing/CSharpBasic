using System.Threading.Tasks;
using CSharpBasic.Models;
using WhereAmI.Controllers;

namespace CSharpBasic.Interface
{
    public interface IGeoIpService
    {
        Task<WhereAmIResponse> GetGeoDataAsync();
    }
}