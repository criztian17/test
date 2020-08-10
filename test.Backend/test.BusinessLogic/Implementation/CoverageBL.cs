using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.BusinessLogic.Interfaces;
using test.BusinessLogic.Mappers;
using test.BusinessLogic.Validators.CoverageValidator;
using test.Common.Dtos.Coverage;
using test.Repository.Entities;
using test.Repository.Repositories.Interfaces;
using test.Utilities.ApiExceptions;
using test.Utilities.Extensions;

namespace test.BusinessLogic.Implementation
{
    /// <summary>
    /// Coverage Business Logic Class
    /// </summary>
    public class CoverageBL : ICoverageBL
    {
        #region Attributes
        private readonly ICoverageRepository _coverageRepository;
        #endregion

        #region Constructor
        public CoverageBL(ICoverageRepository coverageRepository)
        {
            _coverageRepository = coverageRepository;
        }
        #endregion

        #region Public Methods

        public async Task<bool> CreateCoverageAsync(CoverageDto coverage)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<bool, CoverageBL>(async () =>
            {
                ValidateRequiredData(coverage);

                if (await GetCoverageByDescriptionAsync(coverage.Description, false) != null)
                {
                    throw new BusinessException(400, string.Format(Constants.ConstantMessage.Exists, "coverage", "description" , coverage.Description));
                }

                await _coverageRepository.CreateAsync(coverage.ToEntityMapper<CoverageEntity>());

                return await Task.FromResult(true);
            });
        }

        public async Task<bool> DeleteCoveragetAsync(int id)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<bool, CoverageBL>(async () =>
            {
                await ExistAsync(id);

                var client = await _coverageRepository.GetByIdAsync(id);
                
                return await _coverageRepository.DeleteAsync(client);
            });
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<bool, CoverageBL>(async () =>
            {
                if (!await _coverageRepository.ExistAsync(id))
                {
                    throw new BusinessException(400, string.Format(Constants.ConstantMessage.NotExist, "coverage", "id", id));

                }
                return true;
            });
        }

        public async Task<ICollection<CoverageDto>> GetAllAsync()
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<ICollection<CoverageDto>, CoverageBL>(async () =>
            {
                var result = _coverageRepository.GetAll().ToList();

                return await Task.FromResult(result.ToDtoListMapper<CoverageDto>());
            });
        }

        public async Task<CoverageDto> GetCoverageByDescriptionAsync(string description, bool throwException = true)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<CoverageDto, CoverageBL>(async () =>
            {
                var result = _coverageRepository.GetCoveragetByDescription(description).FirstOrDefault();

                if (result == null)
                {
                    if (throwException)
                    {
                        throw new BusinessException(400, string.Format(Constants.ConstantMessage.NotExist, "coverage" ,"description" , description));
                    }

                    return null;
                }

                return await Task.FromResult(result.ToDtoMapper<CoverageDto>());
            });
        }

        public async Task<CoverageDto> GetCoverageByIdAsync(int id)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<CoverageDto, CoverageBL>(async () =>
            {
                await ExistAsync(id);

                var result = await _coverageRepository.GetByIdAsync(id);

                return result.ToDtoMapper<CoverageDto>();
            });
        }

        public async Task<bool> UpdateCoverageAsync(int id, CoverageDto coverage)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<bool, CoverageBL>(async () =>
            {
                await ExistAsync(id);
                ValidateRequiredData(coverage);

                return await _coverageRepository.UpdateAsync(coverage.ToEntityMapper<CoverageEntity>());
            });
        }

        public void ValidateRequiredData(CoverageDto coverage)
        {
            CoverageValidator validationRules = new CoverageValidator();
            validationRules.ValidateRequiredData();

            ValidationResult result = validationRules.Validate(coverage);

            if (!result.IsValid)
            {
                throw new BusinessException(400, result.Errors[0].ErrorMessage);
            }

            return;
        }

        #endregion
    }
}
