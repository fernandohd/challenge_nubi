using Challenge.Infrastructure.Data;
using Challenge.Infrastructure.Data.Contracts;
using Challenge.Infrastructure.Extensions;
using Challenge.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Services
{
    public abstract class ServiceBase<TOptions> where TOptions : HttpOptionsBase, new()
    {
        protected readonly ILogger<ServiceBase<TOptions>> logger;
        private readonly IHttpClientFactory clientFactory;
        protected TOptions Options { get; }

        protected ServiceBase(ILogger<ServiceBase<TOptions>> logger, IHttpClientFactory clientFactory, IOptions<TOptions> options)
        {
            this.logger = logger;
            this.clientFactory = clientFactory;
            Options = options.Value;
        }

        public async Task<TResponse> Get<TResponse>(string url, AuthenticationHeaderValue authentication = null)
        {
            using (HttpClient client = clientFactory.CreateClient(Options.HttpClienteName))
            {
                client.DefaultRequestHeaders.Authorization = authentication;

                logger.LogInformation("GET: {baseAddress}{url}", client.BaseAddress, url);

                using (HttpResponseMessage responseMessage = await client.GetAsync(url))
                {
                    var response = await responseMessage.GetContentWithStatusCodeValidated();

                    logger.LogInformation("GET {statusCode}: {baseAddress}{url}", responseMessage.StatusCode, client.BaseAddress, url);
                    logger.LogDebug("Response: {response}", response);

                    return JsonConvert.DeserializeObject<TResponse>(response);
                }
            }
        }

        public async Task<TResponse> Get<TResponse>(string url, AuthenticationHeaderValue authentication = null, params KeyValuePair<string, string>[] args)
        {
            using (HttpClient client = clientFactory.CreateClient(Options.HttpClienteName))
            {
                client.DefaultRequestHeaders.Authorization = authentication;

                for(int i = 0; i < args.Length; i++)
                {
                    url = $"{url}{(i == 0 ? "?" : "&")}{args[i].Key}={args[i].Value}";
                }

                logger.LogInformation("GET: {baseAddress}{url}", client.BaseAddress, url);

                using (HttpResponseMessage responseMessage = await client.GetAsync(url))
                {
                    var response = await responseMessage.GetContentWithStatusCodeValidated();

                    logger.LogInformation("GET {statusCode}: {baseAddress}{url}", responseMessage.StatusCode, client.BaseAddress, url);
                    logger.LogDebug("Response: {response}", response);

                    return JsonConvert.DeserializeObject<TResponse>(response);
                }
            }
        }

        public async Task Post(string url, DataModelBase body = null, AuthenticationHeaderValue authentication = null)
        {
            using (HttpClient client = clientFactory.CreateClient(Options.HttpClienteName))
            {
                var jsonBody = body?.Serialize();

                client.DefaultRequestHeaders.Authorization = authentication;

                logger.LogInformation("POST: {baseAddress}{url}", client.BaseAddress, url);
                logger.LogDebug("Body: {body}", body?.ToJson());

                using (HttpResponseMessage responseMessage = await client.PostAsync(url, jsonBody))
                {
                    await responseMessage.GetContentWithStatusCodeValidated();

                    logger.LogInformation("POST {statusCode}: {baseAddress}{url}", responseMessage.StatusCode, client.BaseAddress, url);
                }
            }
        }

        public async Task<TResponse> Post<TResponse>(string url, DataModelBase body = null, AuthenticationHeaderValue authentication = null)
        {
            using (HttpClient client = clientFactory.CreateClient(Options.HttpClienteName))
            {
                var jsonBody = body?.Serialize();

                client.DefaultRequestHeaders.Authorization = authentication;

                logger.LogInformation("POST: {baseAddress}{url}", client.BaseAddress, url);
                logger.LogDebug("Body: {body}", body?.ToJson());

                using (HttpResponseMessage responseMessage = await client.PostAsync(url, jsonBody))
                {
                    var response = await responseMessage.GetContentWithStatusCodeValidated();

                    logger.LogInformation("POST {statusCode}: {baseAddress}{url}", responseMessage.StatusCode, client.BaseAddress, url);
                    logger.LogDebug("Response: {response}", response);

                    return JsonConvert.DeserializeObject<TResponse>(response);
                }
            }
        }

        public async Task Put(string url, DataModelBase body = null, AuthenticationHeaderValue authentication = null)
        {
            using (HttpClient client = clientFactory.CreateClient(Options.HttpClienteName))
            {
                var jsonBody = body?.Serialize();

                client.DefaultRequestHeaders.Authorization = authentication;

                logger.LogInformation("PUT: {baseAddress}{url}", client.BaseAddress, url);
                logger.LogDebug("Body: {body}", body?.ToJson());

                using (HttpResponseMessage responseMessage = await client.PutAsync(url, jsonBody))
                {
                    await responseMessage.GetContentWithStatusCodeValidated();

                    logger.LogInformation("PUT {statusCode}: {baseAddress}{url}", responseMessage.StatusCode, client.BaseAddress, url);
                }
            }
        }

        public async Task<TResponse> Put<TResponse>(string url, DataModelBase body = null, AuthenticationHeaderValue authentication = null)
        {
            using (HttpClient client = clientFactory.CreateClient(Options.HttpClienteName))
            {
                var jsonBody = body?.Serialize();

                client.DefaultRequestHeaders.Authorization = authentication;

                logger.LogInformation("PUT: {baseAddress}{url}", client.BaseAddress, url);
                logger.LogDebug("Body: {body}", body?.ToJson());

                using (HttpResponseMessage responseMessage = await client.PutAsync(url, jsonBody))
                {
                    var response = await responseMessage.GetContentWithStatusCodeValidated();

                    logger.LogInformation("PUT {statusCode}: {baseAddress}{url}", responseMessage.StatusCode, client.BaseAddress, url);
                    logger.LogDebug("Response: {response}", response);

                    return JsonConvert.DeserializeObject<TResponse>(response);
                }
            }
        }

        public async Task Delete(string url, AuthenticationHeaderValue authentication = null)
        {
            using (HttpClient client = clientFactory.CreateClient(Options.HttpClienteName))
            {
                client.DefaultRequestHeaders.Authorization = authentication;

                logger.LogInformation("DELETE: {baseAddress}{url}", client.BaseAddress, url);

                using (HttpResponseMessage responseMessage = await client.DeleteAsync(url))
                {
                    await responseMessage.GetContentWithStatusCodeValidated();

                    logger.LogInformation("DELETE {statusCode}: {baseAddress}{url}", responseMessage.StatusCode, client.BaseAddress, url);
                }
            }
        }

        public async Task<TResponse> Delete<TResponse>(string url, AuthenticationHeaderValue authentication = null)
        {
            using (HttpClient client = clientFactory.CreateClient(Options.HttpClienteName))
            {
                client.DefaultRequestHeaders.Authorization = authentication;

                logger.LogInformation("DELETE: {baseAddress}{url}", client.BaseAddress, url);

                using (HttpResponseMessage responseMessage = await client.DeleteAsync(url))
                {
                    var response = await responseMessage.GetContentWithStatusCodeValidated();

                    logger.LogInformation("DELETE {statusCode}: {baseAddress}{url}", responseMessage.StatusCode, client.BaseAddress, url);
                    logger.LogDebug("Response: {response}", response);

                    return JsonConvert.DeserializeObject<TResponse>(response);
                }
            }
        }
    }

    public abstract class ServiceBase<TContext, TEntity>
        where TContext : DbContext
        where TEntity : EntityBase
    {
        protected readonly ILogger<ServiceBase<TContext, TEntity>> logger;
        protected IRepositoryQuery<TContext, TEntity> RepositoryQuery { get; }
        protected IRepositoryCommand<TContext, TEntity> RepositoryCommand { get; }
        protected IUnitOfWork<TContext> UnitOfWork { get; }

        private ServiceBase(ILogger<ServiceBase<TContext, TEntity>> logger, IUnitOfWork<TContext> unitOfWork)
        {
            this.logger = logger;
            UnitOfWork = unitOfWork;
        }
        protected ServiceBase(ILogger<ServiceBase<TContext, TEntity>> logger, IRepositoryQuery<TContext, TEntity> repositoryQuery, IUnitOfWork<TContext> unitOfWork)
            : this(logger, unitOfWork)
        {
            RepositoryQuery = repositoryQuery;
        }

        protected ServiceBase(ILogger<ServiceBase<TContext, TEntity>> logger, IRepositoryCommand<TContext, TEntity> repositoryCommand, IUnitOfWork<TContext> unitOfWork)
            : this(logger, unitOfWork)
        {
            RepositoryCommand = repositoryCommand;
        }
    }

}
