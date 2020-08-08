using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using test.Utilities.ApiExceptions;

namespace test.Utilities.Extensions
{
    /// <summary>
    /// Wrapper class that encapsulate the execution of functions
    /// </summary>
    public static class ExecutionWrapperAPIExtension
    {
        #region "Public Methods"

        /// <summary>
        /// Wrapper for encapsulating the execution of functions and handle the exceptions
        /// </summary>
        /// <typeparam name="C">Method Class</typeparam>
        /// <param name="executionBody">Body to be executed</param>
        /// <returns>The function executed</returns>
        public static ActionResult ExecuteWrapperAPI<C>(HttpContext httpContext, Func<ActionResult> executionBody) where C : class
        {
            ActionResult respuesta = ExecutionWrapperExtension.ExecuteWrapper<ActionResult, C>(executionBody, (ex) =>
            {
                if (ex is BusinessException)
                {
                    BusinessException businessException = (BusinessException)ex;
                    httpContext.Response.StatusCode = businessException.StatusCode;
                    return new JsonResult(businessException.Result);
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            });

            return respuesta;
        }


        #endregion

        #region "Public Async Methods"

        /// <summary>
        /// Wrapper for encapsulating the execution of functions and handle the exceptions
        /// </summary>
        /// <typeparam name="C">Method Class</typeparam>
        /// <param name="httpContext">Http context</param>
        /// <param name="executionBody">Body to be executed</param>
        /// <returns>The function executed</returns>
        public static async Task<ActionResult> ExecuteWrapperAPIAsync<C>(HttpContext httpContext, Func<Task<ActionResult>> executionBody) where C : class
        {
            ActionResult respuesta = await ExecutionWrapperExtension.ExecuteWrapperAsync<ActionResult, C>(executionBody, (ex) =>
            {
                if (ex is BusinessException)
                {
                    BusinessException businessException = (BusinessException)ex;
                    httpContext.Response.StatusCode = businessException.StatusCode;
                    return new JsonResult(businessException.Result);
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            });

            return respuesta;
        }

        #endregion
    }
}
