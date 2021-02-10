using MarkJPriceCSharp9DotNet5.Ch18.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using static System.Console;

namespace MarkJPriceCSharp9DotNet5.Ch18
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers(options =>
                {
                    WriteLine("Default output formatters:");
                    foreach (var formatter in options.OutputFormatters)
                    {
                        if (formatter is OutputFormatter mediaFormatter)
                        {
                            WriteLine(" {0}, Media types: {1}", arg0: mediaFormatter.GetType().Name,
                                arg1: string.Join(", ", mediaFormatter.SupportedMediaTypes));
                        }
                        else
                        {
                            WriteLine($" {formatter.GetType().Name}");
                        }
                    }
                })
                .Services
                .AddSwaggerGen(c =>
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MarkJPriceCSharp9DotNet5.Ch18", Version = "v1" }))
                .AddDbContext<Northwind>(options => options.UseSqlite(_configuration.GetConnectionString("Northwind")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MarkJPriceCSharp9DotNet5.Ch18 v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}