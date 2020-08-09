using FluentValidation;
using test.Common.Dtos.Policy;
using test.Common.Enums;

namespace test.BusinessLogic.Validators.PolicyValidator
{
    /// <summary>
    /// Class for validating the business rules
    /// </summary>
    internal sealed class PolicyValidator : AbstractValidator<PolicyDto>
    {
        /// <summary>
        /// Valites the coverage percentage
        /// </summary>
        internal void ValidateCoveragePercentage()
        {

            RuleFor(x => x.PolicyDetails).ForEach(policy =>
            {
                policy.Must(x => x.CoveragePercentage >= 0).WithMessage(Constants.ConstantMessage.ErrorGreaterPercentage);
            });

            RuleFor(x => x.PolicyDetails).ForEach(policy =>
            {
                policy.Must(x => x.CoveragePercentage <= 100).WithMessage(Constants.ConstantMessage.ErrorLessPercentage);
            });

            ValidateCoveragePercentageBusinessRule();
        }


        internal void ValidateCoveragePercentageBusinessRule()
        {
            When(x => x.RiskType == (int)RiskTypeEnum.High, () =>
            {
                RuleFor(x => x.PolicyDetails).ForEach(policy =>
                {
                    policy.Must(x => x.CoveragePercentage <= 50).WithMessage(Constants.ConstantMessage.ErrorPercentageBusiness);
                });
            });

        }
    }
}
