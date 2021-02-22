using Challenge.Infrastructure.Models;
using System;
using System.Net.Http;

namespace Challenge.Testing.Builders
{
    public class HttpClientBuilder<TOptions> : IHttpClientFactory
        where TOptions : HttpOptionsBase
    {
        public HttpClient CreateClient(string name)
        {
            var option = OptionsMockBuilder.GetOptions<TOptions>();
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(option.UrlBase),
                Timeout = TimeSpan.FromSeconds(15),
            };
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            return httpClient;
        }
    }
}
