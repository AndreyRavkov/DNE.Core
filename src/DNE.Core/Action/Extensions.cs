using System;
using System.Threading.Tasks;

namespace DNE.Core.Action
{
    public static class Extensions
    {
        /// <summary>
        /// Try execute action
        /// </summary>
        /// <param name="action">action</param>
        /// <exception cref="ActionException"></exception>
        public static void Try(System.Action action)
        {
            if (action == null)
            {
                throw new ActionException("ArgumentNullException", new ArgumentNullException(nameof(action)));
            }

            try
            {
                action();
            }
            catch (Exception exception)
            {
                throw new ActionException(exception.Message, exception);
            }
        }

        /// <summary>
        /// Try execute action
        /// </summary>
        /// <param name="action">action</param>
        /// <exception cref="ActionException"></exception>
        public static async Task TryAsync(Func<Task> action)
        {
            if (action == null)
            {
                throw new ActionException("ArgumentNullException", new ArgumentNullException(nameof(action)));
            }

            try
            {
                await action();
            }
            catch (Exception exception)
            {
                throw new ActionException(exception.Message, exception);
            }
        }
        
        /// <summary>
        /// Try execute action
        /// </summary>
        /// <param name="action">action</param>
        /// <exception cref="ActionException"></exception>
        public static async Task<T> TryAsync<T>(Func<Task<T>> action)
        {
            if (action == null)
            {
                throw new ActionException("ArgumentNullException", new ArgumentNullException(nameof(action)));
            }

            try
            {
                return await action();
            }
            catch (Exception exception)
            {
                throw new ActionException(exception.Message, exception);
            }
        }
    }

    public class ActionException : Exception
    {
        public ActionException(string message) : base(message)
        {
        }

        public ActionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}