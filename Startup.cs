using Flight_Projectv2.Repository.Authorization;
using Flight_Projectv2.Repository.Authorization.Amadeus;
using Flight_Projectv2.Repository.FlightSearch;
using Flight_Projectv2.Repository.FlightSearch.Amadeus;
using Flight_Projectv2.Repository.SupplierConnecter;
using Flight_Projectv2.Repository.SupplierConnecter.Amadeus;
using Flight_Projectv2.Services.Authorization;
using Flight_Projectv2.Services.FlightSearch;
using Flight_Projectv2.Services.SupplierConnecter;
using Flight_Projectv2.Services.SupplierConnector;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Projectv2
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Flight_Projectv2", Version = "v1" });
            });

            //REPO
            services.Add(new ServiceDescriptor(typeof(IFlightSearchRepository), typeof(FlightSearchRepository), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IAuthorizationRepository), typeof(AuthorizationRepository), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ISupplierConnectorRepository), typeof(SupplierConnectorRepository), ServiceLifetime.Transient));


            //Service
            services.Add(new ServiceDescriptor(typeof(IFlightSearchService), typeof(FlightSearchService), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IAuthorizationService), typeof(AuthorizationService), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ISupplierConnectorService), typeof(SupplierConnectorService), ServiceLifetime.Transient));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flight_Projectv2 v1"));
            }

            //port enabling  
            //app.UseCors(options => options.WithOrigins("https://localhost:5001").AllowAnyMethod().AllowAnyHeader());
            //app.UseCors(options => options.WithOrigins("https://localhost:44355").AllowAnyMethod().AllowAnyHeader());

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
