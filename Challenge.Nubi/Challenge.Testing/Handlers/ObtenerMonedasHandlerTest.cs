using System.Linq;
using NUnit.Framework;
using Challenge.Testing.Bases;
using Challenge.Testing.Builders;
using Challenge.Domain.Options;
using Challenge.Application.Handlers;
using Challenge.Application.Services.ApiServices;
using Challenge.Application.Services;
using Challenge.Testing.Mocks;
using Challenge.Application.Services.DbServices;
using Challenge.Domain.Contexts;
using Challenge.Domain.Entities;

namespace Challenge.Testing.Handlers
{
    [TestFixture]
    public class ObtenerMonedasHandlerTest : HandlerBaseTest<ObtenerMonedasHandler>
    {
        private IMonedasApiService monedasApiService;
        private ICsvLoggingService loggingService;
        private ICurrencyHistoryDbService currencyHistoryDbService;
        private ObtenerMonedasRequest request;

        [SetUp]
        public void SetUp()
        {
            monedasApiService = ServiceBuilder<MercadoLibreOptions>.GetService<MonedasApiService>();
            loggingService = new CsvLoggingService(new OptionsMock<CsvLoggingOptions>(OptionsMockBuilder.GetOptions<CsvLoggingOptions>()));
            currencyHistoryDbService = ServiceBuilder<ChallengeDbContext, CurrencyHistoryEntity>.GetService<CurrencyHistoryDbService>();
            Handler = new ObtenerMonedasHandler(Logger, monedasApiService, loggingService, currencyHistoryDbService, Mapper);
        }

        [TestCase]
        public void Handle()
        {
            request = new ObtenerMonedasRequest();

            var result = Handler.Handle(request, CancellationToken).Result;

            Assert.IsTrue(result.Any());
        }
    }
}
