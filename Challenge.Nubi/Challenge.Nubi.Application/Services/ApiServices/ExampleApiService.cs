using Challenge.Nubi.Application.DataModels;
using Challenge.Nubi.Application.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Challenge.Nubi.Infrastructure.Services;
using System.Net.Http;
using System.Threading.Tasks;

namespace Challenge.Nubi.Application.Services.ApiServices
{
    public interface IExampleApiService
    {
        Task<ExampleDataModel> ExampleMethodAsync(string data);
    }

    public class ExampleApiService : ServiceBase<ExampleOptions>, IExampleApiService
    {
        private readonly ILogger<ExampleApiService> logger;

        public ExampleApiService(ILogger<ExampleApiService> logger, IHttpClientFactory clientFactory, IOptions<ExampleOptions> options)
            : base(logger, clientFactory, options)
        {
            this.logger = logger;
        }

        public async Task<ExampleDataModel> ExampleMethodAsync(string data)
        {
            logger.LogInformation("Iniciando: {methodName}(data: {data})", nameof(ExampleMethodAsync), data);

            var url = string.Format(Options.UrlExample, data);

            var result = await Get<ExampleDataModel>(url);

            return result;
        }
    }
}
