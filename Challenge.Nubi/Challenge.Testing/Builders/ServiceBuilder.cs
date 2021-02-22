using Challenge.Testing.Mocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Challenge.Infrastructure.Data;
using Challenge.Infrastructure.Models;
using Challenge.Infrastructure.Services;
using System;
using System.Collections.Generic;

namespace Challenge.Testing.Builders
{
    public static class ServiceBuilder
    {
        public static TService GetService<TService>()
        {
            return (TService)Activator.CreateInstance(typeof(TService), new object[] {
                new LoggerFactory().CreateLogger<TService>(),
            });
        }
    }

    public static class ServiceBuilder<TOptions>
        where TOptions : HttpOptionsBase, new()
    {
        public static TService GetService<TService>()
        {
            return (TService)Activator.CreateInstance(typeof(TService), new object[] {
                new LoggerFactory().CreateLogger<TService>(),
                new HttpClientBuilder<TOptions>(),
                new OptionsMock<TOptions>(OptionsMockBuilder.GetOptions<TOptions>())
            });
        }

        public static TService GetService<TService>(params object[] args)
        {
            var basicArgs = new object[] {
                new LoggerFactory().CreateLogger<TService>(),
                new HttpClientBuilder<TOptions>(),
                new OptionsMock<TOptions>(OptionsMockBuilder.GetOptions<TOptions>())
            };
            var argsList = new List<object>();
            argsList.AddRange(basicArgs);
            argsList.AddRange(args);
            return (TService)Activator.CreateInstance(typeof(TService), argsList.ToArray());
        }
    }

    public static class ServiceBuilder<TContext, TEntity>
        where TContext : DbContext, new()
        where TEntity : EntityBase
    {
        public static TService GetService<TService>()
        {
            var configuration = ConfigurationTestBuilder.BuildConfiguration();
            var optionsBuilder = new DbContextOptionsBuilder<TContext>().UseSqlServer(configuration.GetSection("ConnectionStrings:ChallengeDbContext").Value);
            var dbContext = (TContext)Activator.CreateInstance(typeof(TContext), optionsBuilder.Options);

            return (TService)Activator.CreateInstance(typeof(TService), new object[] {
                new LoggerFactory().CreateLogger<TService>(),
                new Repository<TContext, TEntity>(dbContext, false),
                new UnitOfWork<TContext>(dbContext, new QueryManager(), new AppUserService())
            });
        }
    }
}