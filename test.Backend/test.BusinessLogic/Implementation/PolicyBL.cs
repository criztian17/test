using FluentValidation.Results;
using System.Threading.Tasks;
using test.BusinessLogic.Interfaces;
using test.BusinessLogic.Validators.PolicyValidator;
using test.Common.Dtos.Policy;
using test.Repository.Repositories.Interfaces;
using test.Utilities.ApiExceptions;
using test.Utilities.Extensions;

namespace test.BusinessLogic.Implementation
{
    /// <summary>
    /// Plicy Business Logic Class
    /// </summary>
    public class PolicyBL : IPolicyBL
    {
        #region Attributes
        private readonly IPolicyRepository _policyRepository;
        #endregion

        #region Constructor
        public PolicyBL(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        } 
        #endregion
        /// <summary>
        /// Create a new Policy
        /// </summary>
        /// <param name="policy">PolicyDto object</param>
        /// <returns>PolicyDto Object</returns>
        public async Task<bool> CreatePolicyAsync(PolicyDto policy)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<bool,PolicyBL> (async () =>
            {
                ValidateCoveragePerncentage(policy);
                //await _policyRepository.CreateAsync(null);
                return await Task.FromResult(true);
            }); 
        }

        #region Private Methods
        /// <summary>
        /// Valites the Coverage Percentage Rules
        /// </summary>
        /// <param name="policy"></param>
        /// <returns>string</returns>
        private void ValidateCoveragePerncentage(PolicyDto policy)
        {
            PolicyValidator validationRules = new PolicyValidator();
            validationRules.ValidateCoveragePercentage();

            ValidationResult result = validationRules.Validate(policy);

            if (!result.IsValid)
            {
                throw new BusinessException(400, result.Errors[0].ErrorMessage);
            }

            return;
        }
        #endregion
    }
}
