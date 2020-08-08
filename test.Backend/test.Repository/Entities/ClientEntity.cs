using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test.Repository.Entities
{
    /// <summary>
    /// Represents the client model
    /// </summary>
    public class ClientEntity : IEntity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Client Identification
        /// </summary>
        [Required]
        [StringLength(12)]
        public string Identification { get; set; }

        /// <summary>
        /// Client Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<PolicyEntity> Policies { get; set; }
    }
}
