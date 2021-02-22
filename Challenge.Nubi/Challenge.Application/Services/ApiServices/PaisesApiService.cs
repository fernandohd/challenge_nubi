using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Challenge.Domain.DataModels;
using Challenge.Domain.Options;
using Challenge.Infrastructure.Services;
using Challenge.Infrastructure.Exceptions;

namespace Challenge.Application.Services.ApiServices
{
    public interface IPaisesApiService
    {
        Task<IEnumerable<PaisDataModel>> ObtenerPaisesAsync();
        Task<PaisDataModel> ObtenerPaisAsync(string id);
    }

    public class PaisesApiService : ServiceBase<MercadoLibreOptions>, IPaisesApiService
    {
        public PaisesApiService(ILogger<ServiceBase<MercadoLibreOptions>> logger, IHttpClientFactory clientFactory, IOptions<MercadoLibreOptions> options) 
            : base(logger, clientFactory, options) { }

        public async Task<IEnumerable<PaisDataModel>> ObtenerPaisesAsync()
        {
            logger.LogInformation("Obtener paises");

            var url = string.Format(Options.UrlPaises);

            return await Get<IEnumerable<PaisDataModel>>(url);
        }

        public async Task<PaisDataModel> ObtenerPaisAsync(string id)
        {
            logger.LogInformation("Obtener paises");

            if (Options.PaisesInhabilitados.Where(x => x.Equals(id.ToUpper())).Any())
            {
                throw new UnauthorizedAccessProyectException("error 401 unauthorized de http");
            }

            string url;

            if (Options.PaisesEspeciales.Where(x => x.Equals(id.ToUpper())).Any())
            {
                url = string.Format(Options.UrlPais, id.ToUpper());

                return await Get<PaisDataModel>(url);
            }

            url = string.Format(Options.UrlPaises);

            var paises = await Get<IEnumerable<PaisDataModel>>(url);

            return paises.Where(x => x.Id == id.ToUpper()).FirstOrDefault();
        }
    }
}
