using System.Linq;
using NUnit.Framework;
using Challenge.Domain.Options;
using Challenge.Testing.Bases;
using Challenge.Testing.Builders;
using Challenge.Application.Services.ApiServices;

namespace Challenge.Testing.Services.ApiServices
{
    [TestFixture]
    public class MonedasApiServiceTest : ServiceBaseTest<MercadoLibreOptions>
    {
        private IMonedasApiService service;

        [SetUp]
        public void SetUp()
        {
            service = ServiceBuilder<MercadoLibreOptions>.GetService<MonedasApiService>();
        }

        [TestCase()]
        public void ObtenerMonedasAsyncTest()
        {
            var result = service.ObtenerMonedasAsync().Result;

            Assert.IsTrue(result.Any());
        }

        [TestCase("ARS", "CLP")]
        public void ObtenerConversionAsyncTest(string from, string to)
        {
            var result = service.ObtenerConversionAsync(from, to).Result;

            Assert.IsNotNull(result);
        }
    }
}
