using Microsoft.EntityFrameworkCore;
using test.Repository.Entities;

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

        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientEntity>()
                .HasIndex(p => new { p.Identification});

            modelBuilder.Entity<CoverageEntity>()
                .HasIndex(p => new { p.Description});
        } 
        #endregion
    }
}
