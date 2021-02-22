using Autofac;
using Challenge.Nubi.Application.Services.ApiServices;
using Challenge.Nubi.Application.Services.DbServices;
using Challenge.Nubi.Infrastructure.Services;

namespace Challenge.Nubi.API.Configuration
{
    public class ServicesAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region ApiServices

            builder.RegisterType<ExampleApiService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            #endregion

            #region DbServices

            builder.RegisterType<ExampleDbService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            #endregion

            #region SoapServices

            #endregion

            builder.RegisterType<AppUserService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
