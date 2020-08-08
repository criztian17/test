using System.ComponentModel.DataAnnotations;

namespace test.Common.Dtos.Coverage
{
    /// <summary>
    /// CoverageDto Class
    /// </summary>
    public class CoverageDto : IBaseDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Coverage Description
        /// </summary>
        [Required]
        [Display(Name = "Coverage Description")]
        public string Description { get; set; }
    }
}
