using System.Threading.Tasks;
using CSharpBasic.Attributes;
using CSharpBasic.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WhereAmI.Controllers
{
    [Route("api/[controller]")]
    public class WhereAmIController : Controller
    {
        private readonly IGeoIpService _geoIpService;

        public WhereAmIController(IGeoIpService geoIpService)
        {
            _geoIpService = geoIpService;
        }

        [HttpGet, TypeFilter(typeof(ApiTrackingAttribute)), ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            var myGeoData = await _geoIpService.GetGeoDataAsync();

            return new JsonResult(myGeoData);
        }
    }
}