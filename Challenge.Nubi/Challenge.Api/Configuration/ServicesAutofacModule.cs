using Autofac;
using Challenge.Application.Services;
using Challenge.Application.Services.ApiServices;
using Challenge.Application.Services.DbServices;
using Challenge.Infrastructure.Services;

namespace Challenge.Api.Configuration
{
    public class ServicesAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            #region ApiServices

            builder.RegisterType<PaisesApiService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<BusquedaApiService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<MonedasApiService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            #endregion

            #region DbServices

            builder.RegisterType<UserDbService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<CurrencyHistoryDbService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            #endregion

            #region Service

            builder.RegisterType<CsvLoggingService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            #endregion

            builder.RegisterType<AppUserService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
