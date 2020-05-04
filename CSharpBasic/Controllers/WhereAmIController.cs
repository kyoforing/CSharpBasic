using CSharpBasic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CSharpBasic.Attributes;

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

        [HttpGet, ServiceFilter(typeof(ApiTrackingAttribute))]
        public async Task<ActionResult<GeoResponse>> Index()
        {
            var geoDetail = await _geoIpService.GetGeoDetailAsync();
            return new GeoResponse
            {
                Ip = geoDetail.QueriedIp,
                CountryCode = geoDetail.CountryCode
            };
        }
    }
}