using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using test.Common.Dtos.Client;

namespace test.Common.Dtos.Policy
{
    /// <summary>
    /// PolicyDto Class
    /// </summary>
    public class PolicyDto : IBaseDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Policy Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Policy Risk Type
        /// </summary>
        public int RiskType { get; set; }

        /// <summary>
        /// Policy Start Date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Policy Due Date
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Policy's Client
        /// </summary>
        public ClientDto Client { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<PolicyDetailDto> PolicyDetails { get; set; }
    }
}
