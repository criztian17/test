using Microsoft.EntityFrameworkCore;
using test.Repository.Entities;
using test.Repository.Entities.EntityHelper;

namespace test.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        #region DbSets
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<CoverageEntity> Coverages { get; set; }
        public DbSet<PolicyEntity> Policies { get; set; }
        public DbSet<PolicyDetailEntity> PolicyDetails { get; set; }

        public DbSet<ResultEntityHelper> ResultEntityHelpers { get; set; }

        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientEntity>()
                .HasIndex(p => new { p.Identification})
                .IsUnique();

            modelBuilder.Entity<CoverageEntity>()
                .HasIndex(p => new { p.Description})
                .IsUnique();
        } 
        #endregion
    }
}
