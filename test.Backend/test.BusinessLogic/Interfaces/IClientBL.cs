﻿using System.Collections.Generic;
using System.Threading.Tasks;
using test.Common.Dtos.Client;

namespace test.BusinessLogic.Interfaces
{
    /// <summary>
    /// ClientBL Interface
    /// </summary>
    public interface IClientBL
    {
        /// <summary>
        /// Creates new Client
        /// </summary>
        /// <param name="client">ClientDto object</param>
        /// <returns>bool</returns>
        Task<bool> CreateClientAsync(ClientDto client);

        /// <summary>
        /// Get a client by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientDto object</returns>
        Task<ClientDto> GetClientByIdAsync(int id);


        /// <summary>
        /// Validate if the client exists into the database
        /// </summary>
        /// <param name="id">Client Id</param>
        /// <returns>bool</returns>
        Task<bool> ExistAsync(int id);

        /// <summary>
        /// Get a collection of clients
        /// </summary>
        /// <returns>Icollection</returns>
        Task<ICollection<ClientDto>> GetAllAsync();

        /// <summary>
        /// Updates a client
        /// </summary>
        /// <param name="client">ClientDto object</param>
        /// <param name="id">client id</param>
        /// <returns>bool</returns>
        Task<bool> UpdateClientAsync(int id ,ClientDto client);

        /// <summary>
        /// Deletes a client 
        /// </summary>
        /// <param name="id">Client Id</param>
        /// <returns>bool</returns>
        Task<bool> DeleteClientAsync(int id);

        /// <summary>
        /// Get a client by Identification
        /// </summary>
        /// <param name="identification"></param>
        /// <returns>ClientDto</returns>
        Task<ClientDto> GetClientByIdentificationAsync(string identification, bool throwException = true);

        /// <summary>
        /// Validate if the required data is as expected
        /// </summary>
        /// <param name="client">ClientDto object</param>
        void ValidateRequiredData(ClientDto client);
    }
}
