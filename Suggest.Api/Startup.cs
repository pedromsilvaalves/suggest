using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Suggest.Api.Logging;
using Suggest.Infrastructure.Models;
using Suggest.Infrastructure.Repositories;
using Suggest.Services.Repositories;
using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Suggest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddDbContext<SuggestionContext>(opt =>
               opt.UseInMemoryDatabase("Suggestions"));

            services.AddControllers();

            services.AddLoggingSerilog();

            services.AddAutoMapper(new Assembly[]
            {
                Assembly.Load("Suggest.Api"),
                Assembly.Load("Suggest.Services"),
                Assembly.Load("Suggest.Infrastructure")
            });

            services.AddScoped<ISuggestRepository, SuggestRepository>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Suggest.",
                    Description = "API - Suggest.",
                    Version = "v1"
                });

                var apiPath = Path.Combine(AppContext.BaseDirectory, "Suggest.Api.xml");

                c.IncludeXmlComments(apiPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UsePathBase("/suggest");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/suggest/swagger/v1/swagger.json", "API Suggest.");
                c.RoutePrefix = String.Empty;
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
