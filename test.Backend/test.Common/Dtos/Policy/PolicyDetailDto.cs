using System;
using System.Collections.Generic;
using System.Text;

namespace test.Common.Dtos.Policy
{
    public class PolicyDetailDto: IBaseDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Policy
        /// </summary>
        public PolicyDto Policy { get; set; }

        /// <summary>
        /// Policy Price
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Policy Coverage Porcentage
        /// </summary>
        public float CoveragePorcentage { get; set; }
    }
}
