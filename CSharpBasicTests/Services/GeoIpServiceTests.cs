using System.Net.Http;
using System.Threading.Tasks;
using CSharpBasic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CSharpBasicTests.Services
{
    [TestClass()]
    public class GeoIpServiceTests
    {
        private IHttpClientFactory _httpClientFactory;

        [TestInitialize]
        public void SetUp()
        {
            _httpClientFactory = Substitute.For<IHttpClientFactory>();
            _httpClientFactory.CreateClient(Arg.Any<string>()).ReturnsForAnyArgs(new HttpClient());
        }

        [TestMethod()]
        public async Task test_GetMyIp_endPoint_works()
        {
            var service = new GeoIpService(_httpClientFactory);

            var ip = await service.GetMyIp();

            Assert.IsNotNull(ip);
        }
    }
}