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
using WeatherMonitor.Dtos.Mappers;
using WeatherMonitor.Services.Interfaces;
using WeatherMonitor.Services.WeatherForecast;

namespace WeatherMonitor
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Cors Setup
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins(Configuration["ApiConfigs:WeatherFrontEnd:Uri"])
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
            #endregion

            services.AddControllers();

            #region Service Layer
            services.AddHttpClient<IWeatherForecastService, WeatherForecastService>(c =>
            {
                c.BaseAddress = new Uri(Configuration["ApiConfigs:WeatherApi:Uri"]);
                c.DefaultRequestHeaders.Add("key", Configuration["ApiConfigs:WeatherApi:Key"]);
            });
            #endregion

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // DI not working
            services.AddAutoMapper(typeof(WeatherSearchMapper));

            #region Open Api Info
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "WeatherMonitor", 
                    Version = "v1" ,
                    Description = "An API to check local weather conditions",
                    TermsOfService = new Uri(Configuration["OpenApiInfo:TermsUri"]),
                    Contact = new OpenApiContact
                    {
                        Name = "Mutual Vision contact",
                        Url = new Uri(Configuration["OpenApiInfo:ContactUri"])
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Privacy policy",
                        Url = new Uri(Configuration["OpenApiInfo:PolicyUri"])
                    }
                });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherMonitor v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
