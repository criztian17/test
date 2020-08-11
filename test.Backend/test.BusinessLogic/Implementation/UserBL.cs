using FluentValidation.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public UserBL(IUserRepository userRepository , IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        #endregion

        #region MyRegion
        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="user">UserDto object</param>
        /// <returns></returns>
        public async Task<TokenDto> GenerateTokenAsync(UserDto user)
        {
            return await ExecutionWrapperExtension.ExecuteWrapperAsync<TokenDto, UserBL>(async () =>
            {
                ValidateRequiredData(user);

                var userEntity = _userRepository.GetUserUserByUserName(user);

                //if (!userEntity.ToList().Any())
                //{
                //    throw new BusinessException(400, Constants.ConstantMessage.ErrorUserCredentials);
                //}

                //if (user.Password != user.Password)
                //{
                //    throw new BusinessException(400, Constants.ConstantMessage.ErrorUserCredentials);
                //}

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub , user.UserLogin),
                    new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Tokens:Issuer"],
                    _configuration["Tokens:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: credentials);

                var results = new TokenDto
                { 
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Espiration = token.ValidTo
                };

                return await Task.FromResult(results);
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
