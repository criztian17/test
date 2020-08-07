using FluentValidation.Results;
using System.Threading.Tasks;
using test.BusinessLogic.Interfaces;
using test.BusinessLogic.Validators.PolicyValidator;
using test.Common.Enums;
using test.Common.Dtos.Policy;

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
        public Task<PolicyDto> CreatePolicy(PolicyDto policy)
        {
            if (string.IsNullOrEmpty(ValidateCoveragePorncentage(policy)))
            {

            }

            return Task.FromResult(policy);
        }

        #region Private Methods
        /// <summary>
        /// Valites the Coverage Porcentage Rules
        /// </summary>
        /// <param name="policy"></param>
        /// <returns>string</returns>
        private string ValidateCoveragePorncentage(PolicyDto policy)
        {
            PolicyValidator validationRules = new PolicyValidator();
            validationRules.ValidateCoveragePorcentage();

            ValidationResult result = validationRules.Validate(policy);

            if (!result.IsValid)
            {
                return result.Errors[0].ErrorMessage;
            }
            
            return string.Empty;
        }
        #endregion
    }
}
