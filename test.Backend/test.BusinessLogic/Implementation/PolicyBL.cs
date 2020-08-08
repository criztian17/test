using FluentValidation.Results;
using System.Threading.Tasks;
using test.BusinessLogic.Interfaces;
using test.BusinessLogic.Validators.PolicyValidator;
using test.Common.Dtos.Policy;
using test.Utilities.ApiExceptions;
using test.Utilities.Extensions;

namespace test.BusinessLogic.Implementation
{
    /// <summary>
    /// Plicy Business Logic Class
    /// </summary>
    public class PolicyBL : IPolicyBL
    {
        public PolicyBL()
        {

        }
        /// <summary>
        /// Create a new Policy
        /// </summary>
        /// <param name="policy">PolicyDto object</param>
        /// <returns>PolicyDto Object</returns>
        public async Task<PolicyDto> CreatePolicy(PolicyDto policy)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<PolicyDto, PolicyBL > (async () =>
            {
                await ValidateCoveragePerncentage(policy);

                return policy;
            });
        }

        #region Private Methods
        /// <summary>
        /// Valites the Coverage Percentage Rules
        /// </summary>
        /// <param name="policy"></param>
        /// <returns>string</returns>
        private async Task<bool> ValidateCoveragePerncentage(PolicyDto policy)
        {
            PolicyValidator validationRules = new PolicyValidator();
            validationRules.ValidateCoveragePercentage();

            ValidationResult result = validationRules.Validate(policy);

            if (!result.IsValid)
            {
                throw new BusinessException(400, result.Errors[0].ErrorMessage);
            }

            return await Task.FromResult(true);
        }
        #endregion
    }
}
