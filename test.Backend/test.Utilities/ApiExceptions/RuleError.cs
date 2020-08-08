namespace test.Utilities.ApiExceptions
{
    /// <summary>
    /// Class for errors in rules
    /// </summary>
    public sealed class RuleError
    {
        #region "Properties"

        /// <summary>
        /// Message error
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Attempted value
        /// </summary>
        public string AttemptedValue { get; set; }

        /// <summary>
        /// Property Name
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Property to stablish the origin of the message
        /// </summary>
        public string MessageOrigin { get; set; }

        #endregion
    }
}
