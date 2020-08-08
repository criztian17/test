using System.Threading.Tasks;
using test.BusinessLogic.Interfaces;
using test.BusinessLogic.Mappers;
using test.Common.Dtos.Client;
using test.Repository.Entities;
using test.Repository.Repositories.Interfaces;
using test.Utilities.Extensions;

namespace test.BusinessLogic.Implementation
{
    public class ClientBL : IClientBL
    {
        #region Attributes
        private readonly IClientRepository _clientRepository;
        #endregion

        #region Constructor
        public ClientBL(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        #endregion


        #region Public Methods
        public async Task<bool> CreateClientAsync(ClientDto client)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<bool, ClientBL>(async () =>
            {
                //await _policyRepository.CreateAsync(null);
                await _clientRepository.CreateAsync(client.ToEntity<ClientEntity>());
                return await Task.FromResult(true);
            });
        } 
        #endregion
    }
}
