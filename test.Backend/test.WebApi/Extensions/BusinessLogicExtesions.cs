using Microsoft.Extensions.DependencyInjection;
using test.BusinessLogic.Implementation;
using test.BusinessLogic.Interfaces;

namespace test.WebApi.Extensions
{
    public static class BusinessLogicExtesions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services
                .AddScoped<IPolicyBL, PolicyBL>()
                .AddScoped<IClientBL, ClientBL>()
                .AddScoped<ICoverageBL, CoverageBL>()
                .AddScoped<IPolicyDetailBL, PolicyDetailBL>();
            return services;
        }
    }
}
