using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test.Repository.Entities
{
    /// <summary>
    /// Represents a Coverage model
    /// </summary>
    public class CoverageEntity : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public virtual ICollection<PolicyDetailEntity> PolicyDetails { get; set; }
    }
}
