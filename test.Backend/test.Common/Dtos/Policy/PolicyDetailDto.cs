﻿using System.ComponentModel.DataAnnotations;

namespace test.Common.Dtos.Policy
{
    /// <summary>
    /// PolicyDetailDto Class
    /// </summary>
    public class PolicyDetailDto: IBaseDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Policy
        /// </summary>
        public PolicyDto Policy { get; set; }

        /// <summary>
        /// Policy Coverage Percentage
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float CoveragePercentage { get; set; }
    }
}
