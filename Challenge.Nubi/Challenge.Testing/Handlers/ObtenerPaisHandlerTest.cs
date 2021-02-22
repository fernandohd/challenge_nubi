using NUnit.Framework;
using Challenge.Domain.Options;
using Challenge.Testing.Bases;
using Challenge.Testing.Builders;
using Challenge.Application.Handlers;
using Challenge.Application.Services.ApiServices;

namespace Challenge.Testing.Handlers
{
    [TestFixture]
    public class ObtenerPaisHandlerTest : HandlerBaseTest<ObtenerPaisHandler>
    {
        private IPaisesApiService obtenerPagoApiService;
        private ObtenerPaisRequest request;

        [SetUp]
        public void SetUp()
        {
            obtenerPagoApiService = ServiceBuilder<MercadoLibreOptions>.GetService<PaisesApiService>();

            Handler = new ObtenerPaisHandler(Logger, obtenerPagoApiService, Mapper);
        }

        [TestCase("AR")]
        public void Handle(string id)
        {
            request = new ObtenerPaisRequest(id);

            var result = Handler.Handle(request, CancellationToken).Result;
            Assert.IsNotNull(result);
        }
    }
}
