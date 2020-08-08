using Microsoft.EntityFrameworkCore;

namespace test.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DbContext> options) : base(options)
        { 
        
        }
    }
}
