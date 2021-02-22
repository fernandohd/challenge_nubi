using System.Linq;
using NUnit.Framework;
using Challenge.Domain.Options;
using Challenge.Testing.Bases;
using Challenge.Testing.Builders;
using Challenge.Application.Handlers;
using Challenge.Application.Services.ApiServices;

namespace Challenge.Testing.Handlers
{
    [TestFixture]
    public class ObtenerPaisesHandlerTest : HandlerBaseTest<ObtenerPaisesHandler>
    {
        private IPaisesApiService obtenerPagoApiService;
        private ObtenerPaisesRequest request;

        [SetUp]
        public void SetUp()
        {
            obtenerPagoApiService = ServiceBuilder<MercadoLibreOptions>.GetService<PaisesApiService>();

            Handler = new ObtenerPaisesHandler(Logger, obtenerPagoApiService, Mapper);
            request = new ObtenerPaisesRequest();
        }

        [Test]
        public void Handle()
        {
            var result = Handler.Handle(request, CancellationToken).Result;
            Assert.IsTrue(result.Any());
        }
    }
}
