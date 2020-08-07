using System;
using test.Common.Dtos.Client;

namespace test.Common.Dtos.Policy
{
    public class PolicyDto : BaseDto
    {
        /// <summary>
        /// Policy Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Policy Coverage Porcentage
        /// </summary>
        public decimal CoveragePorcentage { get; set; }

        /// <summary>
        /// Policy Start Date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Policy Due Date
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Policy Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Policy Risk Type
        /// </summary>
        public int RiskType { get; set; }

        public ClientDto Client { get; set; }
    }
}
