using Autofac;
using MediatR;
using Challenge.Application;
using Challenge.Infrastructure;
using Challenge.Infrastructure.Models;
using System.Linq;
using System.Reflection;

namespace Challenge.Api.Configuration
{
    public class MappersAutofacModule : Autofac.Module
    {
        private static Assembly[] ApplicationAssemblies
            => new[] { typeof(DummyApplication), typeof(DummyInfrastructure) }.Select(x => x.Assembly).ToArray();

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(ApplicationAssemblies)
                .AsClosedTypesOf(typeof(MapperBase<,>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
