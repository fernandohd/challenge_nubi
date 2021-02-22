using Challenge.Domain.DataModels;
using Challenge.Domain.Options;
using Challenge.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Challenge.Application.Services.ApiServices
{
    public interface IBusquedaApiService
    {
        Task<ItemDataModel> ObtenerItemAsync(string termino);
    }

    public class BusquedaApiService : ServiceBase<MercadoLibreOptions>, IBusquedaApiService
    {
        public BusquedaApiService(ILogger<ServiceBase<MercadoLibreOptions>> logger, IHttpClientFactory clientFactory, IOptions<MercadoLibreOptions> options) 
            : base(logger, clientFactory, options) { }

        public async Task<ItemDataModel> ObtenerItemAsync(string termino)
        {
            logger.LogInformation("Obtener item por termino: {termino}", termino);

            var url = string.Format(Options.UrlBusqueda);

            var args = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("q", termino),
            };

            return await Get<ItemDataModel>(url, null, args);
        }
    }
}
