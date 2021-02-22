using Microsoft.Extensions.Configuration;
using System;

namespace Challenge.Testing.Builders
{
    public static class ConfigurationTestBuilder
    {
        public static IConfiguration BuildConfiguration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .Build();
            return config;
        }
    }
}
