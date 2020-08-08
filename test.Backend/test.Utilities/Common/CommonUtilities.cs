using System;
using System.Diagnostics;
using System.Reflection;

namespace test.Utilities.Common
{
    public static class CommonUtilities
    {
        #region Public Methods
        /// <summary>
        /// Get the name of the executed method
        /// </summary>
        /// <param name="classType">Type of the class</param>
        /// <returns>The name of the method</returns>
        public static string GetExecutedMethod(Type classType)
        {
            try
            {
                string resultValue = string.Concat((classType == null ? string.Empty : classType.FullName));
                StackTrace trace = new StackTrace(false);

                bool isTheMethod = false;

                foreach (StackFrame frame in trace.GetFrames())
                {
                    MethodBase method = frame.GetMethod();

                    if (classType != null)
                    {
                        isTheMethod = (method.DeclaringType == classType && classType.IsAssignableFrom(method.DeclaringType)) ? true : false;
                    }

                    if (isTheMethod)
                    {
                        resultValue = string.Concat(method.DeclaringType.FullName, ".", method.Name, "()");

                        break;
                    }
                }

                return resultValue;
            }
            catch (Exception)
            {
                return "UnknowMethod()";
            }
        }

        /// <summary>
        /// Get the name of the executed method in an async call
        /// </summary>
        /// <param name="classType">Type of class</param>
        /// <returns>The name of the method</returns>
        public static string GetParallelExecutedMethod(Type classType)
        {
            try
            {
                string resultValue = string.Concat((classType == null ? string.Empty : classType.FullName));
                StackTrace trace = new StackTrace(false);

                foreach (StackFrame frame in trace.GetFrames())
                {
                    MethodBase method = frame.GetMethod();

                    if (method.DeclaringType.FullName.Contains(classType.FullName))
                    {
                        resultValue = string.Concat(method.DeclaringType.FullName.ExtractNameExecutedMethod(), "()");
                        break;
                    }
                }

                return resultValue;
            }
            catch (Exception)
            {
                return "UnknowMethod()";
            }
        } 
        #endregion

        #region "Private Methods"

        /// <summary>
        /// Get the name of the method from a string value
        /// </summary>
        /// <param name="value">Value to find</param>
        /// <returns>The name of the method</returns>
        private static string ExtractNameExecutedMethod(this string value)
        {
            int initialPosition = value.IndexOf("<<") + 1;
            int finalPosition = value.IndexOf(">", value.IndexOf(">") + 1);

            return value.Substring(initialPosition + 1, finalPosition - initialPosition);
        }

        #endregion 
    }
}
