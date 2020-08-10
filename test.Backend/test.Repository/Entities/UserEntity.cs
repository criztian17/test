using System.ComponentModel.DataAnnotations;

namespace test.Repository.Entities
{
    /// <summary>
    /// User EntityClass
    /// </summary>
    public class UserEntity : IEntity
    {
        [Key]
        public int Id { get;  set; }

        /// <summary>
        /// User Login
        /// </summary>
        [Required]
        [StringLength(50)]
        public string UserLogin { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}
