using NUnit.Framework;
using Challenge.Domain.Options;
using Challenge.Testing.Mocks;
using Challenge.Testing.Bases;
using Challenge.Testing.Builders;
using Challenge.Application.Handlers;
using Challenge.Application.Services;
using Challenge.Application.Services.ApiServices;

namespace Challenge.Testing.Handlers
{
    [TestFixture]
    public class ObtenerConversionHandlerTest : HandlerBaseTest<ObtenerConversionHandler>
    {
        private IMonedasApiService service;
        private ICsvLoggingService loggingService;
        private ObtenerConversionRequest request;

        [SetUp]
        public void SetUp()
        {
            service = ServiceBuilder<MercadoLibreOptions>.GetService<MonedasApiService>();
            loggingService = new CsvLoggingService(new OptionsMock<CsvLoggingOptions>(OptionsMockBuilder.GetOptions<CsvLoggingOptions>()));
            Handler = new ObtenerConversionHandler(Logger, service, loggingService, Mapper);
        }

        [TestCase("ARS", "USD")]
        public void Handle(string from, string to)
        {
            request = new ObtenerConversionRequest(from, to);

            var result = Handler.Handle(request, CancellationToken);

            Assert.IsNotNull(result);
        }
    }
}
