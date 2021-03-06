﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Repository.Entities
{
    /// <summary>
    ///  Represents the Policy detail model
    /// </summary>
    public class PolicyDetailEntity : IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Policy
        /// </summary>
        [Required]
        public PolicyEntity Policy { get; set; }

        /// <summary>
        /// Policy Coverage Percentage
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal CoveragePercentage { get; set; }

        /// <summary>
        /// Coverage Id
        /// </summary>
        [Required]
        public CoverageEntity Coverage { get; set; }
    }
}
