namespace test.BusinessLogic.Constants
{
    public static class ConstantMessage
    {
        #region Common
        public const string Exists = "The {0} with {1} {2} already exists.";
        public const string NotExist = "The {0} with {1} {2} does not exist.";

        #endregion

        #region Client
        public const string ErrorClientName = "The Client Name must not be null or empty.";
        public const string ErrorClientIdentification = "The Client Identification must not be null or empty.";
        public const string ErrorDeleteClient = "The client with id {0} cannot be delete becasue has at least 1 Policy (Active - Canceled) not exist.";
        #endregion

        #region Policy
        public const string ErrorPercentageBusiness = "The coverage percentage must be equal or less than 50.";
        public const string ErrorGreaterPercentage = "The coverage percentage must be bigger than 0.";
        public const string ErrorLessPercentage = "The coverage percentage must not be bigger than 100.";
        #endregion

        #region Coverage
        public const string ErrorCoverageDescription = "The coverage description must not be null or empty.";
        #endregion
    }
}
