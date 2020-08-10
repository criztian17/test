using FluentValidation;
using test.BusinessLogic.Constants;
using test.Common.Dtos.User;

namespace test.BusinessLogic.Validators.PolicyValidator.UserValidator
{
    /// <summary>
    /// User Validator Class
    /// </summary>
    internal sealed class UserValidator : AbstractValidator<UserDto>
    {
        internal void ValidateRequiredData()
        {
            RuleFor(x => x.Password).NotNull().WithMessage(string.Format(ConstantMessage.ErrorNull, "Password"));
            RuleFor(x => x.UserLogin).NotNull().WithMessage(string.Format(ConstantMessage.ErrorNull, "UserLogin"));
            RuleFor(x => x.UserLogin).NotEmpty().WithMessage(string.Format(ConstantMessage.ErrorEmpty, "UserLogin"));
            RuleFor(x => x.UserLogin).NotEmpty().WithMessage(string.Format(ConstantMessage.ErrorEmpty, "UserLogin"));
        }
    }
}
