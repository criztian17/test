using Newtonsoft.Json;
using System.Collections.Generic;
using test.Common.Dtos.Policy;

namespace test.Common.Dtos.Client
{
    /// <summary>
    /// ClientDto Class
    /// </summary>
    public class ClientDto : IBaseDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Client Identification
        /// </summary>
        public string Identification{get; set;}

        /// <summary>
        /// Client Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Collection of PolicyDto
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<PolicyDto> Policies { get; set; }
    }
}
