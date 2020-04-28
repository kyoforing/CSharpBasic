using CSharpBasic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSharpBasic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhereAmIController : ControllerBase
    {
        private readonly IGeoIpService _geoIpService;

        public WhereAmIController(IGeoIpService geoIpService)
        {
            _geoIpService = geoIpService;
        }

        public async Task<ActionResult<GeoData>> Index()
        {
            var geoDetail = await _geoIpService.GetGeoDetailAsync();
            return new GeoData
            {
                Ip = geoDetail.QueriedIp,
                CountryCode = geoDetail.CountryCode
            };
        }
    }
}