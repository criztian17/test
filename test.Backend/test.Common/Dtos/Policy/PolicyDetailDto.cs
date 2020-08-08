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
        /// Policy Price
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Policy Coverage Percentage
        /// </summary>
        public float CoveragePercentage { get; set; }
    }
}
