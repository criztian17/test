namespace test.Common.Dtos.User
{
    /// <summary>
    /// UserDto Class
    /// </summary>
    public class UserDto : IBaseDto
    {
        /// <summary>
        /// User Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// UserLogin
        /// </summary>
        public string UserLogin { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        public string Password { get; set; }
    }
}
