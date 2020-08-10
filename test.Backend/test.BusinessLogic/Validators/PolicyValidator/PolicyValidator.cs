using FluentValidation;
using System.Linq;
using test.BusinessLogic.Constants;
using test.Common.Dtos.Policy;
using test.Common.Enums;

namespace test.BusinessLogic.Validators.PolicyValidator
{
    /// <summary>
    /// Class for validating the business rules
    /// </summary>
    internal sealed class PolicyValidator : AbstractValidator<PolicyDto>
    {
        internal void ValidateRequiredData()
        {
            RuleFor(x => x.Client).NotNull().WithMessage(string.Format(ConstantMessage.ErrorNull, "Client"));
            RuleFor(x => x.PolicyDetails).NotNull().WithMessage(string.Format(ConstantMessage.ErrorNull, "PolicyDetail"));

            When(x => x.PolicyDetails != null, () =>
            {
                RuleFor(x => x.PolicyDetails).Must(x => !x.Any()).WithMessage(ConstantMessage.ErrorPolicyPolicyDetail);
            });

            RuleFor(x => x.RiskType).Must(x => x >= (int)RiskTypeEnum.Low && x <= (int)RiskTypeEnum.High).WithMessage(ConstantMessage.ErrorPolicyRiskType);
            RuleFor(x => x.Period).GreaterThan(0).WithMessage(string.Format(ConstantMessage.ErrorPolicyPolicyDetail , "Period" , "0"));
            RuleFor(x => x.Price).GreaterThan(0).WithMessage(string.Format(ConstantMessage.ErrorPolicyPolicyDetail , "Price" , "0"));
        }
       
    }
}
