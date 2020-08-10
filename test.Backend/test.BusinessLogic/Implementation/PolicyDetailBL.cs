using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.BusinessLogic.Interfaces;
using test.BusinessLogic.Mappers;
using test.BusinessLogic.Validators.PolicyValidator;
using test.Common.Dtos.Policy;
using test.Repository.Entities;
using test.Repository.Repositories.Interfaces;
using test.Utilities.ApiExceptions;
using test.Utilities.Extensions;

namespace test.BusinessLogic.Implementation
{
    /// <summary>
    /// PolicyDetail Business Logic Class
    /// </summary>
    public class PolicyDetailBL : IPolicyDetailBL
    {
        #region Attributes
        private readonly IPolicyDetailRepository _policyDetailRepository;
        private readonly ICoverageBL _coverageBL;
        #endregion

        #region Constructor
        public PolicyDetailBL(IPolicyDetailRepository policyDetailRepository , ICoverageBL coverageBL)
        {
            _policyDetailRepository = policyDetailRepository;
            _coverageBL = coverageBL;
        }
        #endregion

        #region Public Methods
        public async Task<bool> CreatePolicyDetailtAsync(PolicyDetailDto policyDetail)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<bool, PolicyDetailBL>(async () =>
            {
                ValidateRequiredData(policyDetail);

                _coverageBL.ValidateRequiredData(policyDetail.Coverage);

                 await _policyDetailRepository.CreateAsync(policyDetail.ToEntityMapper<PolicyDetailEntity>(true));

                return await Task.FromResult(true);
            });
        }

        public async Task<bool> DeletePolicyAsync(int id)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<bool, PolicyDetailBL>(async () =>
            {
                await ExistAsync(id);

                var policyDetail = await _policyDetailRepository.GetByIdAsync(id);

                return await _policyDetailRepository.DeleteAsync(policyDetail);
            });
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<bool, PolicyDetailBL>(async () =>
            {
                if (!await _policyDetailRepository.ExistAsync(id))
                {
                    throw new BusinessException(400, string.Format(Constants.ConstantMessage.NotExist, "policyDetail", "id", id));
                }
                return true;
            });
        }

        public async Task<ICollection<PolicyDetailDto>> GetAllAsync()
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<ICollection<PolicyDetailDto>, PolicyDetailBL>(async () =>
            {
                var result = _policyDetailRepository.GetAll().ToList();

                return await Task.FromResult(result.ToDtoListMapper<PolicyDetailDto>(true));
            });
        }

        public async Task<PolicyDetailDto> GetPolicyDetailByIdAsync(int id)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<PolicyDetailDto, PolicyDetailBL>(async () =>
            {
                await ExistAsync(id);

                var result = await _policyDetailRepository.GetByIdAsync(id);

                return result.ToDtoMapper<PolicyDetailDto>();
            });
        }

        public async Task<bool> UpdatePolicyDetailAsync(int id, PolicyDetailDto policyDetail)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<bool, PolicyDetailBL>(async () =>
            {
                await ExistAsync(id);

                ValidateRequiredData(policyDetail);

                _coverageBL.ValidateRequiredData(policyDetail.Coverage);

                return await _policyDetailRepository.UpdateAsync(policyDetail.ToEntityMapper<PolicyDetailEntity>(true));
            });
        }

        public void ValidatePercentageBusinessRule(PolicyDetailDto policyDetail)
        {
            PolicyDetailValidator validationRules = new PolicyDetailValidator();
            validationRules.ValidateCoveragePercentageBusinessRule();

            ValidationResult result = validationRules.Validate(policyDetail);

            if (!result.IsValid)
            {
                throw new BusinessException(400, result.Errors[0].ErrorMessage);
            }

            return;
        }
        #endregion

        #region Private Methods
        private void ValidateRequiredData(PolicyDetailDto policyDetail)
        {
            PolicyDetailValidator validationRules = new PolicyDetailValidator();
            validationRules.ValidateRequiredData();

            ValidationResult result = validationRules.Validate(policyDetail);

            if (!result.IsValid)
            {
                var errors = string.Empty;

                foreach (var item in result.Errors)
                {
                    errors += $"{item.ErrorMessage} ";
                }

                throw new BusinessException(400, errors);
            }

            return;
        }
        #endregion
    }
}
