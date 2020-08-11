using System;

namespace test.Common.Dtos.User
{
    /// <summary>
    /// Token Dto Class
    /// </summary>
    public class TokenDto
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Token Expiration
        /// </summary>
        public DateTime Espiration { get; set; }
    }
}
