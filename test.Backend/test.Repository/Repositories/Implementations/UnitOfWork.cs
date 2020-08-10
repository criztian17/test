using System.Threading.Tasks;
using test.Repository.Repositories.Interfaces;

namespace test.Repository.Repositories.Implementations
{
    /// <summary>
    /// UnitOfWork Class
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public DataContext DataContext { get; }
        
        public UnitOfWork(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<bool> CommitAsync()
        {
            return await DataContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }
    }
}
