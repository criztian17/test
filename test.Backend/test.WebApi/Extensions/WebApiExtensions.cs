using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace test.WebApi.Extensions
{
    public static class WebApiExtensions
    {
        public static IServiceCollection AddMvcCoreWithAddOns(this IServiceCollection services, IConfiguration config)
        {
            var section = config.GetSection("Test");
            services
                .AddMvcCore(options =>
                {
                    var builder = new AuthorizationPolicyBuilder().RequireAuthenticatedUser();

                    // Support IdSrv3 access tokens
                    var apiScope = section.GetValue<string>("Scope");
                    var scopes = apiScope.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //options.Filters.Add(new AuthorizeFilter(ScopePolicy.Create(scopes)));
                })
                .AddCors()
                .AddApiExplorer()
                //.AddAuthorization()
                .AddJsonFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return services;
        }
    }
}
