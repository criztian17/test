namespace test.BusinessLogic.Constants
{
    public static class ConstantMessage
    {
        #region Client
        public const string ErrorClientNameRule = "The Client Name must not be null or empty.";
        #endregion

        #region Policy
        public const string ErrorPercentageBusinessRule = "The coverage percentage must be equal or less than 50.";
        public const string ErrorGreaterPorcentageRule = "The coverage percentage must be bigger than 0.";
        public const string ErrorLessPorcentageRule = "The coverage percentage must not be bigger than 100.";
        #endregion
    }
}
