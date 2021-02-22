using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Challenge.Domain.Options;
using Challenge.Domain.DataModels;
using Challenge.Infrastructure.Services;

namespace Challenge.Application.Services.ApiServices
{
    public interface IMonedasApiService
    {
        Task<IEnumerable<CurrencyDataModel>> ObtenerMonedasAsync();
        Task<CurrencyDataModel> ObtenerMonedaAsync(string id);
        Task<ConversionDataModel> ObtenerConversionAsync(string from, string to);
    }

    public class MonedasApiService : ServiceBase<MercadoLibreOptions>, IMonedasApiService
    {
        public MonedasApiService(ILogger<ServiceBase<MercadoLibreOptions>> logger, IHttpClientFactory clientFactory, IOptions<MercadoLibreOptions> options)
            : base(logger, clientFactory, options) { }

        public async Task<IEnumerable<CurrencyDataModel>> ObtenerMonedasAsync()
        {
            logger.LogInformation("Obtener monedas");

            var url = string.Format(Options.UrlMonedas);

            return await Get<IEnumerable<CurrencyDataModel>>(url);
        }

        public async Task<CurrencyDataModel> ObtenerMonedaAsync(string id)
        {
            logger.LogInformation("Obtener monedas");

            var url = string.Format(Options.UrlMoneda, id);

            return await Get<CurrencyDataModel>(url);
        }

        public async Task<ConversionDataModel> ObtenerConversionAsync(string from, string to)
        {
            logger.LogInformation("Obtener conversion {from} {to}", from, to);

            var url = string.Format(Options.UrlConversion);

            var fromParam = new KeyValuePair<string, string>("from", from);
            var toParam = new KeyValuePair<string, string>("to", to);

            return await Get<ConversionDataModel>(url, null, fromParam, toParam);
        }

    }
}
