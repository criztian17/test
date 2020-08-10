using System;
using System.Threading.Tasks;

namespace test.Repository.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DataContext DataContext { get; }

        Task<bool> CommitAsync();
    }
}
