namespace test.BusinessLogic.Constants
{
    public static class ConstantMessage
    {
        #region Client
        public const string ErrorClientName = "The Client Name must not be null or empty.";
        public const string ErrorClientIdentification = "The Client Identification must not be null or empty.";
        public const string ClientNotExist = "The client with id {0} does not exist.";
        public const string ClientExists = "The client with identification {0} already exists.";
        public const string ErrorDeleteClient = "The client with id {0} cannot be delete becasue has at least 1 Policy (Active - Canceled) not exist.";
        #endregion

        #region Policy
        public const string ErrorPercentageBusiness = "The coverage percentage must be equal or less than 50.";
        public const string ErrorGreaterPercentage = "The coverage percentage must be bigger than 0.";
        public const string ErrorLessPercentage = "The coverage percentage must not be bigger than 100.";
        #endregion
    }
}
