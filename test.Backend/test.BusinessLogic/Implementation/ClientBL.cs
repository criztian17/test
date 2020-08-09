using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.BusinessLogic.Interfaces;
using test.BusinessLogic.Mappers;
using test.BusinessLogic.Validators.ClientValidator;
using test.Common.Dtos.Client;
using test.Repository.Entities;
using test.Repository.Repositories.Interfaces;
using test.Utilities.ApiExceptions;
using test.Utilities.Extensions;

namespace test.BusinessLogic.Implementation
{
    /// <summary>
    /// CLient Business Logic Class
    /// </summary>
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
                ValidateRequiredData(client);

                if (await GetClientByIdentificationAsync(client.Identification , false) != null)
                {
                    throw new BusinessException(400, string.Format(Constants.ConstantMessage.Exists, "client", "identification", client.Identification));
                }

                return await _clientRepository.CreateAsync(client.ToEntityMapper<ClientEntity>());
            });
        }

        public async Task<ClientDto> GetClientByIdAsync(int id)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<ClientDto, ClientBL>(async () =>
            {
                await ExistAsync(id);

                var result = await _clientRepository.GetByIdAsync(id);

                return result.ToDtoMapper<ClientDto>();
            });
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<bool, ClientBL>(async () =>
            {
                if (!await _clientRepository.ExistAsync(id))
                {
                    throw new BusinessException(400, string.Format(Constants.ConstantMessage.NotExist, "client" ,"id" ,id));

                }
                return true;
            });
        }

        public async Task<ICollection<ClientDto>> GetAllAsync()
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<ICollection<ClientDto>, ClientBL>(async () =>
            {
                var result = _clientRepository.GetAll().ToList();

                return await Task.FromResult(result.ToDtoListMapper<ClientDto>());
            });
        }

        public async Task<bool> UpdateClientAsync(int id, ClientDto client)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<bool, ClientBL>(async () =>
            {
                await ExistAsync(id);
                ValidateRequiredData(client);

                return await _clientRepository.UpdateAsync(client.ToEntityMapper<ClientEntity>());
            });
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<bool, ClientBL>(async () =>
            {
                await ExistAsync(id);

                var client = await _clientRepository.GetByIdAsync(id);

                if (client.ToDtoMapper<ClientDto>().Policies.Any())
                {
                    throw new BusinessException(400, string.Format(Constants.ConstantMessage.ErrorDeleteClient, id));
                }

                return await _clientRepository.DeleteAsync(client);
            });
        }

        public async Task<ClientDto> GetClientByIdentificationAsync(string identification , bool throwException = true)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<ClientDto, ClientBL>(async () =>
            {
                var result = _clientRepository.GetClientByIdentification(identification).FirstOrDefault();

                if (result == null)
                {
                    if (throwException)
                    {
                        throw new BusinessException(400, string.Format(Constants.ConstantMessage.NotExist, "client" ,"identification", identification));
                    }

                    return null;
                }

                return await Task.FromResult(result.ToDtoMapper<ClientDto>());
            });


        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Validates if the required data is as expected
        /// </summary>
        /// <param name="client">ClientDto object</param>
        private void ValidateRequiredData(ClientDto client)
        {
            ClientValidator validationRules = new ClientValidator();
            validationRules.ValidateRequiredData();

            ValidationResult result = validationRules.Validate(client);

            if (!result.IsValid)
            {
                throw new BusinessException(400, result.Errors[0].ErrorMessage);
            }

            return;
        }
    }
    #endregion
}
