using CSharpBasic.Controllers;
using CSharpBasic.Models;
using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace CSharpBasicTests.Controllers
{
    [TestClass()]
    public class WhereAmIControllerTests
    {
        [TestMethod()]
        public async Task test_success_case()
        {
            var controller = new WhereAmIController();
            var result = await controller.Index();

            var expected = new GeoData
            {
                Ip = "8.8.8.8",
                CountryCode = "TW"
            };

            expected.ToExpectedObject().ShouldEqual(result.Value);
        }
    }
}