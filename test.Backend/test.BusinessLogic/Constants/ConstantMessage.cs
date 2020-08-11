namespace test.BusinessLogic.Constants
{
    /// <summary>
    /// Constant Messages Class
    /// </summary>
    public static class ConstantMessage
    {
        #region Common
        public const string Exists = "The {0} with {1} {2} already exists.";
        public const string NotExist = "The {0} with {1} {2} does not exist.";
        public const string Greater = "The {0} must be greater than {1}";
        public const string Less = "The {0} must be less than {1}";
        public const string ErrorNull = "The {0} must be not null.";
        public const string ErrorEmpty = "The {0} must be not empty.";
        public const string ErrorRequiredId = "The {0}Id is required.";

        #endregion

        #region Client

        public const string ErrorClientName = "The Client Name must not be null or empty.";
        public const string ErrorClientIdentification = "The Client Identification must not be null or empty.";
        public const string ErrorDeleteClient = "The client with id {0} cannot be delete becasue has at least 1 Policy (Active - Canceled) not exist.";
        #endregion

        #region Policy
        public const string ErrorPolicyPolicyDetail = "It is required at least 1 Policy Detail.";
        public const string ErrorPolicyRiskType = "The RiskType is incorrect.";
        #endregion

        #region Coverage
        public const string ErrorCoverageDescription = "The coverage description must not be null or empty.";
        #endregion

        #region PolicyDetails
        public const string ErrorPercentageBusiness = "The coverage percentage must be equal or less than 50.";
        #endregion

        #region User
        public const string ErrorUserCredentials = "The user or password are incorrect.";
        #endregion
    }
}
