using CSharpBasic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSharpBasic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhereAmIController : ControllerBase
    {
        public async Task<ActionResult<GeoData>> Index()
        {
            return new GeoData
            {
                Ip = "8.8.8.8",
                CountryCode = "TW"
            };
        }
    }
}