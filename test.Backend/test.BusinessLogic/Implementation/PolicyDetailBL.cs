using System.Collections.Generic;
using System.Threading.Tasks;
using test.BusinessLogic.Interfaces;
using test.Common.Dtos.Policy;

namespace test.BusinessLogic.Implementation
{
    public class PolicyDetailBL : IPolicyDetailBL
    {
        public Task<bool> CreatePolicyDetailtAsync(PolicyDetailDto policyDetail)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeletePolicyAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<PolicyDetailDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<PolicyDetailDto> GetPolicyDetailByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdatePolicyDetailAsync(int id, PolicyDetailDto policyDetail)
        {
            throw new System.NotImplementedException();
        }
    }
}
