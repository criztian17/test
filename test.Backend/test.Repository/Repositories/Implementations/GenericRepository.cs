using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using test.Repository.Entities;
using test.Repository.Repositories.Interfaces;

namespace test.Repository.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Methods
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return _unitOfWork.DataContext.Set<T>().AsNoTracking();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await this._unitOfWork.DataContext.Set<T>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> CreateAsync(T entity , bool Commit = true)
        {
            try
            {
                await this._unitOfWork.DataContext.Set<T>().AddAsync(entity);

                if (Commit)
                {
                    await _unitOfWork.CommitAsync(); 
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateAsync(T entity , bool Commit = true)
        {
            try
            {
                this._unitOfWork.DataContext.Set<T>().Update(entity);
                return Commit ? await _unitOfWork.CommitAsync() : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(T entity , bool Commit = true)
        {
            try
            {
                this._unitOfWork.DataContext.Set<T>().Remove(entity);
                return Commit ? await _unitOfWork.CommitAsync() : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExistAsync(int id)
        {
            try
            {
                return await this._unitOfWork.DataContext.Set<T>().AnyAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        #endregion
    }
}
