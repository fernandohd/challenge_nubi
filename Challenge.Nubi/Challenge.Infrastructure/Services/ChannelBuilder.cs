using System;
using System.ServiceModel;

namespace Challenge.Infrastructure.Services
{
    public interface IChannelBuilder
    {
        ChannelFactory<T> BuildChannel<T>(string uri);
    }

    public class ChannelBuilder : IChannelBuilder
    {
        private BasicHttpSecurityMode basicHttpSecurityMode = BasicHttpSecurityMode.None;

        private HttpClientCredentialType httpClientCredentialType = HttpClientCredentialType.Basic;

        public ChannelBuilder WithBasicHttpSecurityMode(BasicHttpSecurityMode basicHttpSecurityMode)
        {
            this.basicHttpSecurityMode = basicHttpSecurityMode;

            return this;
        }

        public ChannelBuilder WithHttpClientCredentialType(HttpClientCredentialType httpClientCredentialType)
        {
            this.httpClientCredentialType = httpClientCredentialType;

            return this;
        }

        public ChannelFactory<T> BuildChannel<T>(string uri)
        {
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new ArgumentException("La url no puede ser nula o vacia.");
            }

            var basicHttpBinding = new BasicHttpBinding(basicHttpSecurityMode);

            basicHttpBinding.Security.Transport.ClientCredentialType = httpClientCredentialType;

            var endpointAddress = new EndpointAddress(new Uri(uri));

            var factory = new ChannelFactory<T>(basicHttpBinding, endpointAddress);

            return factory;
        }
    }
}
