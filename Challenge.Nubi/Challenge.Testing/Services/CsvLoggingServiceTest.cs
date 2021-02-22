using NUnit.Framework;
using Challenge.Domain.Options;
using Challenge.Testing.Mocks;
using Challenge.Testing.Builders;
using Challenge.Application.Services;

namespace Challenge.Testing.Services
{
    [TestFixture]
    public class CsvLoggingServiceTest
    {
        private ICsvLoggingService service;

        [SetUp]
        public void SetUp()
        {
            service = new CsvLoggingService(new OptionsMock<CsvLoggingOptions>(OptionsMockBuilder.GetOptions<CsvLoggingOptions>()));
        }

        [TestCase("Test log")]
        public void WriteLine(string data)
        {
            service.WriteLine(data).Wait();

            Assert.Pass();
        }
    }
}
