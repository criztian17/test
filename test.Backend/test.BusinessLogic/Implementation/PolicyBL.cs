using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.BusinessLogic.Interfaces;
using test.BusinessLogic.Validators.PolicyValidator;
using test.Common.Dtos.Policy;
using test.Common.Enums;
using test.Repository;
using test.Repository.Repositories.Interfaces;
using test.Utilities.ApiExceptions;
using test.Utilities.Extensions;

namespace test.BusinessLogic.Implementation
{
    /// <summary>
    /// Policy Business Logic Class
    /// </summary>
    public class PolicyBL : IPolicyBL
    {
        #region Attributes
        private readonly IPolicyRepository _policyRepository;
        private readonly IPolicyDetailBL _policyDetailBL;
        private readonly IClientBL _clientBL;
        private readonly DataContext _dataContext;
        private static string errors;
        #endregion

        #region Constructor
        public PolicyBL(IPolicyRepository policyRepository, IPolicyDetailBL policyDetailBL, IClientBL clientBL, DataContext dataContext)
        {
            _policyRepository = policyRepository;
            _policyDetailBL = policyDetailBL;
            _clientBL = clientBL;
            _dataContext = dataContext;
        }
        #endregion
        /// <summary>
        /// Create a new Policy
        /// </summary>
        /// <param name="policy">PolicyDto object</param>
        /// <returns>PolicyDto Object</returns>
        public async Task<bool> CreatePolicyAsync(PolicyDto policy)
        {
            //No wrapper because there is a transaction
            try
            {
                ValidateRequiredData(policy);

                _clientBL.ValidateRequiredData(policy.Client);

                if (policy.RiskType == (int)RiskTypeEnum.High)
                {
                    policy.PolicyDetails.ToList().ForEach(x => _policyDetailBL.ValidatePercentageBusinessRule(x));
                }

                using (var transaction = _dataContext.Database.BeginTransaction())
                {

                }

                //await _policyRepository.CreateAsync(null);
            return await Task.FromResult(true);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }



        public Task<bool> DeleteCoveragetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<PolicyDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<PolicyDto> GetPolicyByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateCoverageAsync(int id, PolicyDto coverage)
        {
            throw new System.NotImplementedException();
        }

        #region Private Methods
        /// <summary>
        /// Validates the required data
        /// </summary>
        /// <param name="policy"></param>
        private void ValidateRequiredData(PolicyDto policy)
        {
            PolicyValidator validationRules = new PolicyValidator();
            validationRules.ValidateRequiredData();

            ValidationResult result = validationRules.Validate(policy);

            if (!result.IsValid)
            {
                errors = string.Empty;

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
