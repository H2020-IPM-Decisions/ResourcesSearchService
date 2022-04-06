using System;
using H2020.IPMDecisions.SCH.API.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace H2020.IPMDecisions.SCH.API
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
            services.AddHttpClient<IMicroservicesInternalCommunicationHttpProvider, MicroservicesInternalCommunicationHttpProvider>(client =>
            {
                client.BaseAddress = new Uri(Configuration["MicroserviceInternalCommunication:ApiGatewayAddress"]);
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "H2020 IPM Decisions - Resource Search Service API", Version = "v1" });
            });

            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                if (env.IsProduction())
                {
                    app.UseForwardedHeaders();
                    app.UseHsts();
                    app.UseHttpsRedirection();
                }
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected error happened. Try again later.");
                    });
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            var apiBasePath = Configuration["MicroserviceInternalCommunication:SearchMicroservice"];
            app.UseSwagger(c =>
                       {
                           c.RouteTemplate = apiBasePath + "swagger/{documentName}/swagger.json";
                       });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/{apiBasePath}swagger/v1/swagger.json", "H2020 IPM Decisions - Resource Search Service API");
                c.RoutePrefix = $"{apiBasePath}swagger";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
