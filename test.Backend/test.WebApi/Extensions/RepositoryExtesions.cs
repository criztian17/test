using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using test.Repository;

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
            return service;
        }
    }
}
