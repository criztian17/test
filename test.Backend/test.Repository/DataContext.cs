using Microsoft.EntityFrameworkCore;
using test.Repository.Entities;

namespace test.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<CoverageEntity> Coverages { get; set; }
        public DbSet<PolicyEntity> Policies { get; set; }
        public DbSet<PolicyDetailEntity> PolicyDetails { get; set; }

    }
}
