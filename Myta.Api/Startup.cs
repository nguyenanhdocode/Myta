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
using Myta.Infrastructure;
using Myta.Domain;
using Myta.Service;
using Microsoft.AspNetCore.Diagnostics;
using Myta.Domain.Common;
using Newtonsoft.Json;
using System.Text;

namespace Myta.Api
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
            services.AddControllers();

            services.AddDomainServices();
            services.AddInfrastructureServices(Configuration.GetConnectionString("SqlConnection"));
            services.AddServiceServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Myta.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
            , ILoggerFactory loggerFactory, ILogger<Startup> logger)
        {
            loggerFactory.AddLog4Net();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Myta.Api v1"));
            }

            app.UseExceptionHandler(c => c.Run(async (context) =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;

                await Task.Factory.StartNew(() => logger.LogError(exception.StackTrace));

                var response = new ErrorResult(ApiCodes.E500, exception.StackTrace);
                var json = JsonConvert.SerializeObject(response);

                context.Response.Redirect(string.Format("/api/error/error_500?exMessage={0}", exception.Message));
            }));

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
