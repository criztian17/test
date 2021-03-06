﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using test.WebApi.Extensions;

namespace test.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method Get called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //.AddMvcCoreWithAddOns(Configuration)

            services.AddVersioning()
                .AddSwaggerDocumentation()
                .AddBusinessLogic()
                .AddRepository(Configuration)         
                .AddAthentication(Configuration);

        }

        // This method Get called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            var corsOrigins = Configuration.GetValue<string>("CORSOrigins").Split(",");
            if (corsOrigins.Any())
            {
                app.UseCors(builder => builder
                    .WithOrigins(corsOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            }

            app.UseHttpsRedirection()
            .UseMvc()
            .UseSwaggerDocumentation(Configuration, provider);
            //.UseAuthentication();
        }
    }
}
