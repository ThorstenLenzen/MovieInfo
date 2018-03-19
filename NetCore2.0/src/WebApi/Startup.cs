using System;
using System.IO;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Toto.MovieInfo.DataAccess;
using Toto.MovieInfo.PersistenceModel;
using Toto.MovieInfo.ServiceModel;
using Toto.MovieInfo.WebApi.Utilities;

namespace Toto.MovieInfo.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("allowAll", policy => policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            services
                .AddMvc(options => { options.Filters.Add(typeof(ValidatorActionFilter)); })
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<ActorForCreate>());

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("v1", new Info { Version = "v1", Title = "MovieInfo WebApi" });
                setupAction.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Toto.MovieInfo.WebApi.xml"));
            });

            services.AddSingleton<IActorRepository, MongoBasedActorRepository>();
            services.AddTransient<IModelIdGenerator<Actor>, actorKeyGenerator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ConfigureGeneralExceptionHandling(app, env);

            app.UseCors("allowAll");
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(setupActions => { setupActions.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieInfo API V1"); });

            ConfigurAutomapper();
        }

        private static void ConfigureGeneralExceptionHandling(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;

                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                        var exceptionMessage = exceptionHandlerFeature.Error.ToString();

                        await context.Response.WriteAsync(exceptionMessage);
                    });
                });
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unknown error occurred. In case this error persists, please contact your support team.");
                    });
                });
            }
        }

        private static void ConfigurAutomapper()
        {
            Mapper.Initialize(configuration =>
            {
                configuration.CreateMap<ActorForUpdate, Actor>();
                configuration.CreateMap<ActorForCreate, Actor>();

                configuration.CreateMap<Actor, ActorForMultiDisplay>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                    .ForMember(dest => dest.Age,  opt => opt.MapFrom(src => src.BirthDate.GetCurrentAge())); ;
            });
        }
    }
}
