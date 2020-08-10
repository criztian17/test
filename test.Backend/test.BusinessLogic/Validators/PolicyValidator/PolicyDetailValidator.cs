using FluentValidation;
using test.BusinessLogic.Constants;
using test.Common.Dtos.Policy;

namespace test.BusinessLogic.Validators.PolicyValidator
{
    internal sealed class PolicyDetailValidator : AbstractValidator<PolicyDetailDto>
    {
        /// <summary>
        /// Valites the coverage percentage
        /// </summary>
        internal void ValidateCoveragePercentage()
        {
            RuleFor(x => x.CoveragePercentage).Must(x => x > 0).WithMessage(string.Format(ConstantMessage.Greater, "Coverage Percentage", "0"));
            RuleFor(x => x.CoveragePercentage).Must(x => x < 100).WithMessage(string.Format(ConstantMessage.Less, "Coverage Percentage", "0"));
        }

        internal void ValidateRequiredData()
        {
            ValidateCoveragePercentage();
            RuleFor(x => x.Coverage).NotNull().WithMessage(string.Format(ConstantMessage.ErrorNull , "Coverage")); ;
        }

        internal void ValidateCoveragePercentageBusinessRule()
        {
          RuleFor(x => x.CoveragePercentage).Must(x => x <= 50).WithMessage(ConstantMessage.ErrorPercentageBusiness);
        }
    }
}
