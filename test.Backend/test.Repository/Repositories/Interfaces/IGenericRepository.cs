using System.Linq;
using System.Threading.Tasks;

namespace test.Repository.Repositories.Interfaces
{
    /// <summary>
    /// Generic Repository Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(int id);

        Task<T> CreateAsync(T entity , bool Commit = true);

        Task<bool> UpdateAsync(T entity , bool Commit = true);

        Task<bool> DeleteAsync(T entity , bool Commit = true);

        Task<bool> ExistAsync(int id);
    }
}
