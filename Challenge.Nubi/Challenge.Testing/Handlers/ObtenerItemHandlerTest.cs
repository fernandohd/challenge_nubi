using NUnit.Framework;
using Challenge.Domain.Options;
using Challenge.Testing.Bases;
using Challenge.Testing.Builders;
using Challenge.Application.Handlers;
using Challenge.Application.Services.ApiServices;

namespace Challenge.Testing.Handlers
{
    [TestFixture]
    public class ObtenerItemHandlerTest : HandlerBaseTest<ObtenerItemHandler>
    {
        private IBusquedaApiService obtenerPagoApiService;
        private ObtenerItemRequest request;

        [SetUp]
        public void SetUp()
        {
            obtenerPagoApiService = ServiceBuilder<MercadoLibreOptions>.GetService<BusquedaApiService>();

            Handler = new ObtenerItemHandler(Logger, obtenerPagoApiService, Mapper);
        }

        [TestCase("iphone")]
        public void Handle(string termino)
        {
            request = new ObtenerItemRequest(termino);

            var result = Handler.Handle(request, CancellationToken).Result;

            Assert.IsNotNull(result);
        }
    }
}
