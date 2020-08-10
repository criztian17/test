using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using test.Repository;
using test.Repository.Repositories.Implementations;
using test.Repository.Repositories.Interfaces;

namespace test.WebApi.Extensions
{
    public static class RepositoryExtesions
    {
        public static IServiceCollection AddRepository(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<DataContext>(cfg =>
            { 
                cfg.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            service.AddScoped<IClientRepository, ClientRepository>();
            service.AddScoped<ICoverageRepository, CoverageRepository>();
            service.AddScoped<IPolicyRepository, PolicyRepository>();
            service.AddScoped<IPolicyDetailRepository, PolicyDetailRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            return service;
        }
    }
}
