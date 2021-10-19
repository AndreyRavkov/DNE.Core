using System;

namespace DNE.Core.Action
{
    public static class Require
    {
        /// <summary>
        /// Require that object should be not null
        /// </summary>
        /// <param name="value">source object</param>
        /// <param name="objectName">object name</param>
        /// <param name="errorMessage">error message</param>
        /// <exception cref="RequireException"></exception>
        public static void ArgNotNull(object value, string objectName, string errorMessage = "")
        {
            if (value == null)
            {
                throw new RequireException(errorMessage, new ArgumentNullException(objectName));
            }
        }
        
        /// <summary>
        /// Require that condition condition is valid
        /// </summary>
        /// <param name="condition">bool condition</param>
        /// <param name="errorMessage">error message</param>
        /// <exception cref="RequireException"></exception>
        public static void That(bool condition, string errorMessage)
        {
            if (!condition)
            {
                throw new RequireException(errorMessage);
            }
        }
        
        /// <summary>
        /// Require that source string should be not empty and whitespace
        /// </summary>
        /// <param name="value">source string</param>
        /// <param name="errorMessage">error message</param>
        /// <exception cref="RequireException"></exception>
        public static void ArgNotEmptyOrWhitespace(string value, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
            {
                throw new RequireException(errorMessage);
            }
        }

        public static void ArgMaxLength(string value, string property, int maxLength)
        {
            Require.That(value.Length <= maxLength, $"{property} can't be more than {maxLength} characters length.");
        }
    }

    public class RequireException : Exception
    {
        public RequireException(string message) : base(message)
        {
        }

        public RequireException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}