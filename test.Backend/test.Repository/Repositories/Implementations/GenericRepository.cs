using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using test.Repository.Entities;
using test.Repository.Repositories.Interfaces;

namespace test.Repository.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        #region Attributes
        private readonly DataContext context;
        #endregion

        #region Public Methods
        public GenericRepository(DataContext context)
        {
            this.context = context;
        }

        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.context.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> CreateAsync(T entity)
        {
            await this.context.Set<T>().AddAsync(entity);
            return await SaveAllAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            this.context.Set<T>().Update(entity);
            return await SaveAllAsync();
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            this.context.Set<T>().Remove(entity);
            return await SaveAllAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await this.context.Set<T>().AnyAsync(e => e.Id == id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
