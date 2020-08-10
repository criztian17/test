using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Repository.Entities
{
    /// <summary>
    /// Represents the Policy model
    /// </summary>
    public class PolicyEntity : IEntity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Policy Description
        /// </summary>
        [Required]
        [StringLength(255)]
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
        [Column(TypeName = "decimal(16,2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Policy's Client
        /// </summary>
        [Required]
        public ClientEntity Client { get; set; }

        /// <summary>
        /// Collection of PolicyDetailEntity
        /// </summary>
        public ICollection<PolicyDetailEntity> PolicyDetails { get; set; }
    }
}
