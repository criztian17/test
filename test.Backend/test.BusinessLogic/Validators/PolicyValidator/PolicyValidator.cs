using FluentValidation;
using System;
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
        /// Valites the coverage porcentage
        /// </summary>
        internal void ValidateCoveragePorcentage()
        {
            RuleFor(x => x.CoveragePorcentage).LessThanOrEqualTo(100).WithMessage(Constants.ConstantMessage.ErrorLessPorcentageRule);
            RuleFor(x => x.CoveragePorcentage).GreaterThan(0).WithMessage(Constants.ConstantMessage.ErrorGreaterPorcentageRule);
            RuleFor(x => x.RiskType).Equal((int)RiskTypeEnum.Alto).DependentRules(() => {
                RuleFor(x => x.CoveragePorcentage).LessThan(50).WithMessage(Constants.ConstantMessage.ErrorPorcentageRule);
            });
        }
    }
}
