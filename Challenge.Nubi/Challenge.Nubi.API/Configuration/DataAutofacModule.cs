using Autofac;
using Microsoft.EntityFrameworkCore;
using Challenge.Nubi.Application.Contexts;
using Challenge.Nubi.Infrastructure.Data;
using Challenge.Nubi.Infrastructure.Data.Contracts;
using Challenge.Nubi.Infrastructure.Services;

namespace Challenge.Nubi.API.Configuration
{
    public class DataAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExampleDbContext>()
                .As(typeof(DbContext))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(UnitOfWork<>))
                .As(typeof(IUnitOfWork<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<StoredProcedureRepository<ExampleDbContext>>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<QueryManager>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<ChannelBuilder>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<,>))
                .As(typeof(IRepositoryQuery<,>))
                .WithParameter("traking", false);

            builder.RegisterGeneric(typeof(Repository<,>))
                .As(typeof(IRepositoryCommand<,>))
                .WithParameter("traking", false);
        }
    }
}
