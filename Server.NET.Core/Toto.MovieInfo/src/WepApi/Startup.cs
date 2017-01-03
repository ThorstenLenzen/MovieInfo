using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Toto.MovieInfo.DataAccess;
using Toto.MovieInfo.DataAccess.EF;
using Toto.MovieInfo.ModelFactory;
using Toto.MovieInfo.PersistenceModel;
using Toto.MovieInfo.ServiceModel;

namespace Toto.MovieInfo.WepApi
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddMvcOptions(options => options.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));

            var connectionString = Configuration["connectionStrings:movieContext"];
            services.AddDbContext<MoviesContext>(o => o.UseSqlServer(connectionString));

            services.AddTransient<IQueryHandler<GetMovieByIdQuery, Movie>, GetMovieByIdQueryHandler>();
            services.AddTransient<IQueryHandler<GetMoviesQuery, ICollection<Movie>>, GetMoviesQueryHandler>();
            services.AddTransient<IServiceModelFactory, ServiceModelFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler();

            app.UseStatusCodePages();

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Movie, MovieOverview>();
            //    //cfg.CreateMap<ICollection<Movie>, List<MovieOverview>>();
            //});

            app.UseMvc();
        }
    }
}
