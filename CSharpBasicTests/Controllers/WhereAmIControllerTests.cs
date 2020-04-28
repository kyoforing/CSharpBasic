using CSharpBasic.Controllers;
using CSharpBasic.Models;
using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;

namespace CSharpBasicTests.Controllers
{
    [TestClass()]
    public class WhereAmIControllerTests
    {
        private IGeoIpService _geoIpService;
        private WhereAmIController _sut;

        [TestInitialize]
        public void SetUp()
        {
            _geoIpService = Substitute.For<IGeoIpService>();
            _sut = new WhereAmIController(_geoIpService);
        }

        [TestMethod()]
        public async Task test_success_case()
        {
            GivenGeoDetail("8.8.8.8", "TW");

            var result = await _sut.Index();

            new GeoResponse
            {
                Ip = "8.8.8.8",
                CountryCode = "TW"
            }.ToExpectedObject().ShouldEqual(result.Value);
        }

        private void GivenGeoDetail(string queriedIp, string countryCode)
        {
            _geoIpService.GetGeoDetailAsync().ReturnsForAnyArgs(new GeoDetail
            {
                Status = "success",
                Country = "Taiwan",
                CountryCode = countryCode,
                Region = "TPE",
                RegionName = "Taipei City",
                City = "Taipei",
                ZipCode = "",
                Latitude = 25.0478,
                Longitude = 121.5318,
                Timezone = "Asia/Taipei",
                Isp = "UBBNET",
                Org = "TFN Media Co., Ltd.",
                As = "AS24164 UNION BROADBAND NETWORK",
                QueriedIp = queriedIp
            });
        }
    }
}