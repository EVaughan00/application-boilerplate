using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BuildingBlocks.Utils.Exceptions;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.IO;
using System;
using AuthResource.API.Initializers;
using Application.Config;
using BuildingBlocks.Common.Events;
using AuthResource.Domain.Events;
using BuildingBlocks.Common.Events.Bus;

namespace AuthResource.API 
{
    public class Startup {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services) {

            services.InitializeAll(Configuration);
            services.AddLogging(logging => logging.AddConsole());
            services.Configure<MongoDBSettings>(Configuration.GetSection("MongoDB"));

            var container = new ContainerBuilder();
            
            container.Populate(services);
            container.RegisterModule(new RepositoryModule());
            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new EventBusModule());

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory logger) {
            
            var pathBase = Directory.GetCurrentDirectory();
            
            if (!string.IsNullOrEmpty(pathBase)){
                logger.CreateLogger<Startup>().LogDebug("Using PATH BASE '{pathBase}'", pathBase);
                app.UsePathBase(pathBase);
            }    
            
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseHsts();             
            }

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseRouting();
            // app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth Resource v1");
            });

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
