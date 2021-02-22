using Autofac;
using Autofac.Features.Variance;
using AutoMapper;
using Challenge.Nubi.API.Configuration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Challenge.Nubi.Application;
using Challenge.Nubi.Application.Contexts;
using Challenge.Nubi.Application.Options;
using Challenge.Nubi.Infrastructure;
using Challenge.Nubi.Infrastructure.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace Challenge.Nubi.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<ExampleDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString:ExampleDbContext")));

            services.AddMvc().AddMvcOptions(options => options.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllers();

            MediatorRegister(services);

            ConfigureSwagger(services);

            services.Configure<ExampleOptions>(Configuration.GetSection("ExampleOptions"));

            services.AddHttpClient(Configuration.GetSection("ExampleOptions:HttpClienteName").Value, httpClient =>
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.Timeout = TimeSpan.FromMilliseconds(15000);
                httpClient.BaseAddress = new Uri(Configuration.GetSection("ExampleOptions:UrlBase").Value);
            });

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterModule(new DataAutofacModule());
            builder.RegisterModule(new MediatrAutofacModule());
            builder.RegisterModule(new ServicesAutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseErrorHandlingMiddleware();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Configuration.GetSection("SwaggerConfiguration:EndpointUrl").Value, Configuration.GetSection("SwaggerConfiguration:EndpointDescription").Value);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void MediatorRegister(IServiceCollection services)
        {
            Assembly[] applicationAssembliesMediator = new[] { typeof(DummyApplication), typeof(DummyInfrastructure) }.Select(x => x.Assembly).ToArray();
            Assembly[] domainAssembliesMediator = new[] { typeof(DummyInfrastructure), typeof(DummyDomain) }.Select(x => x.Assembly).ToArray();

            services.AddMediatR(applicationAssembliesMediator);
            services.AddMediatR(domainAssembliesMediator);
        }

        public void ConfigureSwagger(IServiceCollection services)
        {
            var contact = new OpenApiContact()
            {
                Name = Configuration.GetSection("SwaggerConfiguration:ContactName").Value,
                Email = Configuration.GetSection("SwaggerConfiguration:ContactMail").Value
            };

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc(Configuration.GetSection("SwaggerConfiguration:DocNameV1").Value,
                    new OpenApiInfo
                    {
                        Title = Configuration.GetSection("SwaggerConfiguration:DocInfoTitle").Value,
                        Version = Configuration.GetSection("SwaggerConfiguration:DocInfoVersion").Value,
                        Description = Configuration.GetSection("SwaggerConfiguration:DocInfoDescription").Value,
                        Contact = contact
                    }
                );
            });
        }
    }
}
