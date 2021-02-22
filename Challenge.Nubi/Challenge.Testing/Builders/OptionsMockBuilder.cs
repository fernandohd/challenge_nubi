using Microsoft.Extensions.Configuration;
using Challenge.Domain.Options;

namespace Challenge.Testing.Builders
{
    public static class OptionsMockBuilder
    {
        public static TOptions GetOptions<TOptions>() where TOptions : class
        {
            var configuration = ConfigurationTestBuilder.BuildConfiguration();

            if (typeof(TOptions) == typeof(MercadoLibreOptions))
            {
                var section = configuration.GetSection("MercadoLibre").Get<MercadoLibreOptions>();
                return section as TOptions;
            }

            if (typeof(TOptions) == typeof(CsvLoggingOptions))
            {
                var section = configuration.GetSection("CsvLogging").Get<CsvLoggingOptions>();
                return section as TOptions;
            }

            return null;
        }
    }
}
