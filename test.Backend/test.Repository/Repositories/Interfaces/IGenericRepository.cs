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

        Task<bool> CreateAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);

        Task<bool> ExistAsync(int id);
    }
}
