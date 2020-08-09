using FluentValidation;
using test.Common.Dtos.Client;

namespace test.BusinessLogic.Validators.ClientValidator
{
    /// <summary>
    /// Class for validating the client required data
    /// </summary>
    internal sealed class ClientValidator : AbstractValidator<ClientDto>
    {
        /// <summary>
        /// Validates the required fields
        /// </summary>
        internal void ValidateRequiredData()
        {

            RuleFor(x => x.Identification).NotEmpty().NotNull().WithMessage(Constants.ConstantMessage.ErrorClientIdentification);
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage(Constants.ConstantMessage.ErrorClientName);
        }
    }
}
