using Challenge.Testing.Builders;
using Challenge.Testing.Mocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Challenge.Infrastructure.Data;
using Challenge.Infrastructure.Data.Contracts;
using Challenge.Infrastructure.Models;
using Challenge.Infrastructure.Services;
using System;
using System.Net.Http;

namespace Challenge.Testing.Bases
{
    public abstract class ServiceBaseTest<TOptions> where TOptions : HttpOptionsBase, new()
    {
        public ILogger Logger { get; }
        public IHttpClientFactory ClientFactory { get; }
        public IOptions<TOptions> Options { get; }

        protected ServiceBaseTest()
        {
            Logger = new LoggerFactory().CreateLogger<ServiceBaseTest<TOptions>>();
            ClientFactory = new HttpClientBuilder<TOptions>();
            Options = new OptionsMock<TOptions>(OptionsMockBuilder.GetOptions<TOptions>());
        }
    }

    public abstract class ServiceBaseTest<TContext, TEntity> where TContext : DbContext where TEntity : EntityBase
    {
        public ILogger Logger;
        public TContext DbContext { get; }
        public Repository<TContext, TEntity> Repository { get; }
        public IUnitOfWork<TContext> UnitOfWork { get; }

        protected ServiceBaseTest()
        {
            var configuration = ConfigurationTestBuilder.BuildConfiguration();
            var optionsBuilder = new DbContextOptionsBuilder<TContext>().UseSqlServer(configuration.GetSection("ConnectionStrings:ChallengeDbContext").Value);

            Logger = new LoggerFactory().CreateLogger<ServiceBaseTest<TContext, TEntity>>();
            DbContext = (TContext)Activator.CreateInstance(typeof(TContext), optionsBuilder.Options);
            Repository = new Repository<TContext, TEntity>(DbContext, false);
            UnitOfWork = new UnitOfWork<TContext>(DbContext, new QueryManager(), new AppUserService());
        }
    }


}
