using HK.ToolKit.Exceptions;
using System;

namespace HK.Toolkit.Core
{
    public static class Extensions
    {
        /// <summary>
        /// Converts caller base type to given type dynamically.
        /// </summary>
        /// <typeparam name="T">Base caller type</typeparam>
        /// <param name="input">Target type</param>
        /// <returns>Returns New type</returns>
        public static TOutput To<TOutput>(this object input)
        {
            try
            {
                if (input == null || input == DBNull.Value) throw new InputIsNotConvertableToRequiredTypeException();

                return (TOutput)Convert.ChangeType(input, typeof(TOutput));
            }
            catch (Exception ex)
            {
                throw new InputIsNotConvertableToRequiredTypeException(input, typeof(TOutput), ex.Message);
            }
        }

        /// <summary>
        /// Use To Format Strings really fast.
        /// </summary>
        /// <param name="format">string with placeholders</param>
        /// <param name="args">arguments in order</param>
        /// <returns>Formatted String</returns>
        public static string FillPattern(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }
}