namespace test.BusinessLogic.Constants
{
    public static class ConstantMessage
    {
        #region Client
        public const string ErrorClientNameRule = "The Client Name must not be null or empty.";
        #endregion

        #region Policy
        public const string ErrorPorcentageRule = "The coverage porcentage must be less than 50.";
        public const string ErrorGreaterPorcentageRule = "The coverage porcentage must be bigger than 0.";
        public const string ErrorLessPorcentageRule = "The coverage porcentage must not be bigger than 100.";
        #endregion
    }
}
