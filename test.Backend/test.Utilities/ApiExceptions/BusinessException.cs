using System;
using System.Collections.Generic;

namespace test.Utilities.ApiExceptions
{
    public class BusinessException : Exception
    {
        #region Properties
        /// <summary>
        /// Status code for the http response
        /// </summary>
        public int StatusCode { get; private set; }

        /// <summary>
        /// Object result
        /// </summary>
        public List<RuleError> Result { get; private set; }
        #endregion

        #region "Constructors"

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="statusCode">Status code for the http response</param>
        /// <param name="result">Object result</param>
        public BusinessException(int statusCode, List<RuleError> result)
        {
            StatusCode = statusCode;
            Result = result;
        }

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="statusCode">Status code for the http response</param>
        /// <param name="errorMessage">Error message</param> 
        /// <param name="messageOrigin">Origin of the message</param>
        /// <param name="attemptedValue">Attempted Value</param>
        /// <param name="propertyName">Property name</param>
        public BusinessException(int statusCode, string errorMessage, string messageOrigin = "", string attemptedValue = "", string propertyName = "")
        {
            StatusCode = statusCode;
            Result = new List<RuleError>
            {
                new RuleError()
                {
                    AttemptedValue = attemptedValue,
                    ErrorMessage = errorMessage,
                    PropertyName = propertyName,
                    MessageOrigin = !string.IsNullOrEmpty(messageOrigin) ? messageOrigin : string.Empty
                }
            };

        }

        #endregion 
    }
}
