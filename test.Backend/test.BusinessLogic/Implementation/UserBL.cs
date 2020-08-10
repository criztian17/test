using FluentValidation.Results;
using System.Threading.Tasks;
using test.BusinessLogic.Interfaces;
using test.BusinessLogic.Validators.PolicyValidator.UserValidator;
using test.Common.Dtos.User;
using test.Repository.Repositories.Interfaces;
using test.Utilities.ApiExceptions;
using test.Utilities.Extensions;

namespace test.BusinessLogic.Implementation
{
    /// <summary>
    /// User Business Logic Class
    /// </summary>
    public class UserBL : IUserBL
    {
        #region Attributes
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructor
        public UserBL(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region MyRegion
        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="user">UserDto object</param>
        /// <returns></returns>
        public async Task<bool> GenerateTokenAsync(UserDto user)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<bool, UserBL>(async () =>
            {
                ValidateRequiredData(user);

                var userEntity = _userRepository.GetUserUserByUserName(user);

                return await Task.FromResult(true);
            });
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Validate the user credentials
        /// </summary>
        /// <param name="user"></param>
        private void ValidateRequiredData(UserDto user)
        {
            UserValidator validationRules = new UserValidator();
            validationRules.ValidateRequiredData();

            ValidationResult result = validationRules.Validate(user);

            if (!result.IsValid)
            {
                var errors = string.Empty;

                foreach (var item in result.Errors)
                {
                    errors += $"{item.ErrorMessage} ";
                }

                throw new BusinessException(400, errors);
            }

            return;
        }
        #endregion
    }
}
