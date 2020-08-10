using FluentValidation;
using test.Common.Dtos.Coverage;

namespace test.BusinessLogic.Validators.CoverageValidator
{
    /// <summary>
    /// Class for validating the required coverage data
    /// </summary>
    internal sealed class CoverageValidator : AbstractValidator<CoverageDto>
    {
        /// <summary>
        /// Validate the required fields
        /// </summary>
        internal void ValidateRequiredData()
        {
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage(Constants.ConstantMessage.ErrorCoverageDescription);
        }
    }
}
