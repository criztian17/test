using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Policy Risk Type
        /// </summary>
        [Required]
        public int RiskType { get; set; }

        /// <summary>
        /// Policy Start Date
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Policy Period
        /// </summary>
        [Required]
        public int Period { get; set; }

        /// <summary>
        /// Policy State
        /// </summary>
        [Required]
        public int State { get; set; } 

        /// <summary>
        /// Policy Price
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Price { get; set; }

        /// <summary>
        /// Policy's Client
        /// </summary>
        public ClientDto Client { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<PolicyDetailDto> PolicyDetails { get; set; }
    }
}
