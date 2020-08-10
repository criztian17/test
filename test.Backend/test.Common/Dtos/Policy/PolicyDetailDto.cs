using System.ComponentModel.DataAnnotations;
using test.Common.Dtos.Coverage;

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
        [Required]
        public PolicyDto Policy { get; set; }

        /// <summary>
        /// Policy Coverage Percentage
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal CoveragePercentage { get; set; }

        /// <summary>
        /// Coverage
        /// </summary>
        [Required]
        public CoverageDto Coverage { get; set; }
    }
}
