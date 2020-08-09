using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace test.WebApi.Extensions
{
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Extension method to setup the Swagger
        /// </summary>
        /// <param name="services"></param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options =>
                //while we have multiple versions of dto objects this is needed to not break swagger
                options.CustomSchemaIds(x => x.FullName)


               

            );

            return services;
        }

        /// <summary>
        /// Extension method to setup the Swagger environment
        /// </summary>
        /// <param name="app"></param>
        /// <param name="config"></param>
        /// <param name="provider"></param>
        /// <returns>IApplicationBuilder</returns>
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app, IConfiguration config, IApiVersionDescriptionProvider provider)
        {
            app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"Test API {description.GroupName.ToUpperInvariant()}");
                    }
                    options.DocumentTitle = "Test API Documentation";
                    //options.OAuthClientId(clientId);
                });

            return app;
        }
    }

    /// <summary>
    /// Swagger Options Class
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IConfiguration _config;
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IConfiguration config, IApiVersionDescriptionProvider provider)
        {
            _config = config;
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
           
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    new Info()
                    {
                        Title = $"Test {description.ApiVersion}",
                        Version = description.ApiVersion.ToString(),
                    });
            }
            options.EnableAnnotations();

            options.AddSecurityDefinition("Bearer", new ApiKeyScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = "header",
                Type = "apiKey"
            });

        }
    }
}
