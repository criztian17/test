using System;
using System.Threading.Tasks;
using test.Utilities.ApiExceptions;
using test.Utilities.Common;

namespace test.Utilities.Extensions
{
    /// <summary>
    /// Wrapper class that encapsulate the execution of functions
    /// </summary>
    public class ExecutionWrapperExtension
    {
        #region "Public Methods"

        /// <summary>
        /// Wrapper for encapsulating the execution of functions and handle the exceptions
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <typeparam name="C">Method Class</typeparam>
        /// <param name="executionBody">Body to be executed</param>
        /// <param name="doInError">Do when error occours</param>
        /// <param name="doInFinally">Do when finally</param>
        /// <param name="throwException">Indicates if throw an exception or not</param>
        /// <returns>The function executed</returns>
        public static T ExecuteWrapper<T, C>(Func<T> executionBody, Func<Exception, T> doInError, Func<T, T> doInFinally, bool throwException = true) where C : class
        {
            T returnValue = default;
            //never used?
            //Guid correlationId = Guid.NewGuid();
            try
            {
                returnValue = executionBody();
            }
            catch (Exception exception)
            {
                string methodName = CommonUtilities.GetExecutedMethod(typeof(C));

                exception = exception.InnerException == null ? exception : exception.GetBaseException();

                if (exception is BusinessException == false)
                {
                    ///Escribir en serilog
                }

                if (doInError == null)
                {
                    if (exception is BusinessException)
                    {
                        BusinessException businessException = (BusinessException)exception;

                        if (throwException)
                        {
                            throw new BusinessException(businessException.StatusCode, businessException.Result);
                        }
                    }
                    else
                    {
                        if (throwException)
                        {
                            throw new Exception(exception.Message);
                        }
                    }
                }
                else
                {
                    returnValue = doInError(exception);
                }
            }

            finally
            {
                if (doInFinally != null)
                {
                    returnValue = doInFinally(returnValue);
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Wrapper for encapsulating the execution of functions and handle the exceptions
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <typeparam name="C">Method Class</typeparam>
        /// <param name="executionBody">Body to be executed</param>
        /// <param name="doInError">Do when error occours</param>
        /// <returns>The function executed</returns>
        public static T ExecuteWrapper<T, C>(Func<T> executionBody, Func<Exception, T> doInError) where C : class
        {
            return ExecuteWrapper<T, C>(executionBody, doInError, null);
        }

        /// <summary>
        /// Wrapper for encapsulating the execution of functions and handle the exceptions
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <typeparam name="C">Method Class</typeparam>
        /// <param name="executionBody">Body to be executed</param>
        /// <returns>The function executed</returns>
        public static T ExecuteWrapper<T, C>(Func<T> executionBody) where C : class
        {
            return ExecuteWrapper<T, C>(executionBody, null, null);
        }

        /// <summary>
        /// Wrapper for encapsulating the execution of functions and handle the exceptions
        /// </summary>
        /// <typeparam name="C">Method Class</typeparam>
        /// <param name="executionBody">Body to be executed</param>
        public static void ExecuteWrapper<C>(Action executionBody) where C : class
        {
            bool nada = ExecuteWrapper<bool, C>(() =>
            {
                executionBody();
                return false;
            });
        }

        #endregion

        #region "Public Async Methods"

        /// <summary>
        /// Wrapper for encapsulating the execution of functions and handle the exceptions
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <typeparam name="C">Method Class</typeparam>
        /// <param name="executionBody">Body to be executed</param>
        /// <param name="doInError">Do when error occours</param>
        /// <param name="doInFinally">Do when finally</param>
        /// <param name="throwException">Indicates if throw an exception or not</param>
        /// <returns>The function executed</returns>
        public static async Task<T> ExecuteWrapperAsync<T, C>(Func<Task<T>> executionBody, Func<Exception, T> doInError, Func<T, T> doInFinally, bool throwException = true) where C : class
        {
            T returnValue = default(T);
            Guid correlationId = Guid.NewGuid();
            try
            {
                returnValue = await executionBody();
            }
            catch (Exception exception)
            {
                string methodName = CommonUtilities.GetParallelExecutedMethod(typeof(C));
                exception = exception.InnerException == null ? exception : exception.GetBaseException();

                if (exception is BusinessException == false)
                {
                }

                if (doInError == null)
                {
                    if (exception is BusinessException)
                    {
                        BusinessException businessException = (BusinessException)exception;

                        if (throwException)
                        {
                            throw new BusinessException(businessException.StatusCode, businessException.Result);
                        }
                    }
                    else
                    {
                        if (throwException)
                        {
                            throw new Exception(exception.Message);
                        }
                    }
                }
                else
                {
                    returnValue = doInError(exception);
                }
            }

            finally
            {
                if (doInFinally != null)
                {
                    returnValue = doInFinally(returnValue);
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Wrapper for encapsulating the execution of functions and handle the exceptions
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <typeparam name="C">Method Class</typeparam>
        /// <param name="executionBody">Body to be executed</param>
        /// <param name="doInError">Do when error occours</param>
        /// <returns>The function executed</returns>
        public static async Task<T> ExecuteWrapperAsync<T, C>(Func<Task<T>> executionBody, Func<Exception, T> doInError) where C : class
        {
            return await ExecuteWrapperAsync<T, C>(executionBody, doInError, null);
        }

        /// <summary>
        /// Wrapper for encapsulating the execution of functions and handle the exceptions
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <typeparam name="C">Method Class</typeparam>
        /// <param name="executionBody">Body to be executed</param>
        /// <returns>The function executed</returns>
        public static async Task<T> ExecuteWrapperAsync<T, C>(Func<Task<T>> executionBody) where C : class
        {
            return await ExecuteWrapperAsync<T, C>(executionBody, null, null);
        }

        #endregion
    }
}
