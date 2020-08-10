using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Repository.Entities;
using test.Repository.Repositories.Interfaces;

namespace test.Repository
{
    /// <summary>
    /// Seed Class
    /// </summary>
    public class Seed
    {
        #region Atributos
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        public Seed(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Public Method
        /// <summary>
        /// Insert the initial data
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            await _unitOfWork.DataContext.Database.EnsureCreatedAsync();

            if (!_unitOfWork.DataContext.Clients.Any())
            {
                var clients = new List<ClientEntity>
                {
                    new ClientEntity { Identification = "890103", Name = "Cristian Gutierrez" },
                    new ClientEntity { Identification = "890104", Name = "Juan Arboleda" },
                    new ClientEntity { Identification = "890105", Name = "Sara Arango" },
                    new ClientEntity { Identification = "890106", Name = "Luis Carmona" },
                    new ClientEntity { Identification = "890107", Name = "Pilar Vargas" },
                    new ClientEntity { Identification = "890108", Name = "Sandra Castrillon" }
                };

                await _unitOfWork.DataContext.Clients.AddRangeAsync(clients);
                await _unitOfWork.CommitAsync();
            }

            if (!_unitOfWork.DataContext.Coverages.Any())
            {
                var coverages = new List<CoverageEntity>
                {
                    new CoverageEntity{Description = "Terremoto" },
                    new CoverageEntity{Description = "Incendio" },
                    new CoverageEntity{Description = "Perdida" },
                    new CoverageEntity{Description = "Robo" }
                };

                await _unitOfWork.DataContext.Coverages.AddRangeAsync(coverages);
                await _unitOfWork.CommitAsync();
            }
        }
        #endregion
    }
}
