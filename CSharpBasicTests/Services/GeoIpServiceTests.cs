using CSharpBasic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpBasicTests.Services
{
    [TestClass()]
    public class GeoIpServiceTests
    {
        private IHttpClientFactory _httpClientFactory;
        private GeoIpService _sut;

        [TestInitialize]
        public void SetUp()
        {
            _httpClientFactory = Substitute.For<IHttpClientFactory>();
            _httpClientFactory.CreateClient(Arg.Any<string>()).ReturnsForAnyArgs(new HttpClient());
            _sut = new GeoIpService(_httpClientFactory);
        }

        [TestMethod()]
        public async Task test_GetMyIp_endPoint_works()
        {
            var ip = await _sut.GetMyIpAsync();

            Assert.AreEqual(4, ip.Split('.').Length);
        }

        [TestMethod()]
        public async Task test_GetGeoDetailAsync_endPoint_works()
        {
            var detail = await _sut.GetGeoDetailAsync("8.8.8.8");

            Assert.AreEqual(4, detail.QueriedIp.Split('.').Length);
        }
    }
}