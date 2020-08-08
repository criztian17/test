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
        public string Description { get; set; }
    }
}
