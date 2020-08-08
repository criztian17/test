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
        /// Create new Client
        /// </summary>
        /// <param name="client">ClientDto object</param>
        /// <returns></returns>
        Task<bool> CreateClientAsync(ClientDto client);
    }
}
