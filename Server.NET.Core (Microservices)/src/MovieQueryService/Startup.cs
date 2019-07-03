using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Swashbuckle.AspNetCore.Swagger;
using Toto.MovieInfo.MovieQueryService.Queries;
using Toto.DataAccess.Mongo;

namespace Toto.MovieInfo.MovieQueryService
{
    public class Startup
    {
        private readonly Container _container = new Container();

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.UseSimpleInjectorAspNetRequestScoping(_container);

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            InitializeContainer(app);

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/swagger/swagger.json", "My API V1");
            });

            app.UseMvc();
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Add application presentation components:
            _container.RegisterMvcControllers(app);
            _container.RegisterMvcViewComponents(app);

            //// Add application services. For instance:
            //container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            _container.Register<IMovieOverviewQueryHandler, MovieOverviewQueryHandler>(Lifestyle.Transient);
            _container.Register<IPersistenceContext>(() => new MongoPersistenceContext(Configuration.GetValue<string>(""), ""), Lifestyle.Transient);

            //// Cross-wire ASP.NET services (if any). For instance:
            //container.RegisterSingleton(app.ApplicationServices.GetService<ILoggerFactory>());

            //// The following registers a Func<T> delegate that can be injected as singleton,
            //// and on invocation resolves a MVC IViewBufferScope service for that request.
            //container.RegisterSingleton<Func<IViewBufferScope>>(
            //    () => app.GetRequestService<IViewBufferScope>());

            // NOTE: Do prevent cross-wired instances as much as possible.
            // See: https://simpleinjector.org/blog/2016/07/

            _container.Verify();
        }
    }
}
