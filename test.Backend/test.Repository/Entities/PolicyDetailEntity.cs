using System.ComponentModel.DataAnnotations;

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
        public float CoveragePercentage { get; set; }

        /// <summary>
        /// Coverage Type
        /// </summary>
        public CoverageEntity Coverage { get; set; }
    }
}
