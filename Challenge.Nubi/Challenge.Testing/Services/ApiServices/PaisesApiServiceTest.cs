using System.Linq;
using NUnit.Framework;
using Challenge.Domain.Options;
using Challenge.Testing.Bases;
using Challenge.Testing.Builders;
using Challenge.Application.Services.ApiServices;

namespace Challenge.Testing.Services.ApiServices
{
    [TestFixture]
    public class PaisesApiServiceTest : ServiceBaseTest<MercadoLibreOptions>
    {
        private IPaisesApiService service;

        [SetUp]
        public void SetUp()
        {
            service = ServiceBuilder<MercadoLibreOptions>.GetService<PaisesApiService>();
        }

        [TestCase()]
        public void ObtenerPaisesAsyncTest()
        {
            var result = service.ObtenerPaisesAsync().Result;

            Assert.IsTrue(result.Any());
        }

        [TestCase("AR")]
        public void ObtenerPaisAsyncTest(string id)
        {
            var result = service.ObtenerPaisAsync(id).Result; ;

            Assert.IsNotNull(result);
        }
    }
}
