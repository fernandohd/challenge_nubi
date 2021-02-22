using NUnit.Framework;
using Challenge.Testing.Bases;
using Challenge.Testing.Builders;
using Challenge.Domain.Options;
using Challenge.Application.Services.ApiServices;

namespace Challenge.Testing.Services.ApiServices
{
    [TestFixture]
    public class BusquedaApiServiceTest : ServiceBaseTest<MercadoLibreOptions>
    {
        private IBusquedaApiService service;

        [SetUp]
        public void SetUp()
        {
            service = ServiceBuilder<MercadoLibreOptions>.GetService<BusquedaApiService>();
        }

        [TestCase("iphone")]
        public void ObtenerItemsAsyncTest(string termino)
        {
            var result = service.ObtenerItemAsync(termino).Result;

            Assert.IsNotNull(result);
        }
    }
}
