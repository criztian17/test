using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.BusinessLogic.Interfaces;
using test.BusinessLogic.Validators.PolicyValidator;
using test.Common.Dtos.Policy;
using test.Common.Enums;
using test.Repository.Entities.EntityHelper;
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
        private readonly IUnitOfWork _unitOfWork;
        private static string errors;
        #endregion

        #region Constructor
        public PolicyBL(IPolicyRepository policyRepository, IPolicyDetailBL policyDetailBL , IUnitOfWork unitOfWork)
        {
            _policyRepository = policyRepository;
            _policyDetailBL = policyDetailBL;
            _unitOfWork = unitOfWork;
        }
        #endregion
        /// <summary>
        /// Create a new Policy
        /// </summary>
        /// <param name="policy">PolicyDto object</param>
        /// <returns>PolicyDto Object</returns>
        public async Task<bool> CreatePolicyAsync(PolicyDto policy)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<bool, PolicyBL>(async () =>
            {

                ValidateRequiredData(policy);

                if (policy.RiskType == (int)RiskTypeEnum.High)
                {
                    policy.PolicyDetails.ToList().ForEach(x => _policyDetailBL.ValidatePercentageBusinessRule(x));
                }

                policy.PolicyDetails.ToList().ForEach(x => _policyDetailBL.ValidateRequiredData(x));

                using (var transaction = _unitOfWork.DataContext.Database.BeginTransaction())
                {
                    var StartDate = policy.StartDate.ToString();

                    string query = $"{Constants.ConstantProcs.ExecProcPolicy} '{policy.Description}'," +
                                   $"{policy.RiskType},'{StartDate}',{policy.Period},{policy.State},{policy.Price},{policy.Client.Id}";

                    var entityHelper = _unitOfWork.DataContext.Set<ResultEntityHelper>().FromSql(query).FirstOrDefault();

                    if (entityHelper.Id == 0)
                    {
                        transaction.Rollback();
                        throw new System.Exception(entityHelper.ErrorMessage);
                    }

                    foreach (PolicyDetailDto policyDetail in policy.PolicyDetails)
                    {
                        query = $"{Constants.ConstantProcs.ExecProcPolicyDetail} {entityHelper.Id} , {policyDetail.CoveragePercentage} , {policyDetail.Coverage.Id}";
                        entityHelper = _unitOfWork.DataContext.Set<ResultEntityHelper>().FromSql(query).FirstOrDefault();

                        if (entityHelper.Id == 0)
                        {
                            transaction.Rollback();
                            throw new System.Exception(entityHelper.ErrorMessage);
                        }
                    }
                    transaction.Commit();
                }

                return await Task.FromResult(true);
            });
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
