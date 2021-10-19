using System;
using System.Threading.Tasks;

namespace DNE.Core.Action
{
    public static class Extensions
    {
        /// <summary>
        /// Try execute action
        /// </summary>
        /// <param name="action">action to executes in try block</param>
        /// <param name="catchAction">action to executes in catch block</param>
        /// <param name="finalAction">action to executes in finally block</param>
        public static void Try(System.Action action, Action<Exception> catchAction = null,
                               System.Action finalAction = null)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            try
            {
                action();
            }
            catch (Exception exception)
            {
                if (catchAction == null)
                {
                    throw;
                }
                catchAction(exception);
            }
            finally
            {
                if (finalAction != null)
                {
                    finalAction();
                }
            }
        }

        /// <summary>
        /// Try execute action
        /// </summary>
        /// <param name="action">action to executes in try block</param>
        /// <param name="catchAction">action to executes in catch block</param>
        /// <param name="finalAction">action to executes in finally block</param>
        public static async Task TryAsync(Func<Task> action,
                                          Func<Exception, Task> catchAction = null,
                                          System.Action finalAction = null)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            try
            {
                await action().ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (catchAction == null)
                {
                    throw;
                }
                await catchAction(exception).ConfigureAwait(false);
            }
            finally
            {
                if (finalAction != null)
                {
                    finalAction();
                }
            }
        }

        /// <summary>
        /// Try execute action
        /// </summary>
        /// <param name="action">action to executes in try block</param>
        /// <param name="catchAction">action to executes in catch block</param>
        /// <param name="finalAction">action to executes in finally block</param>
        public static async Task<T> TryAsync<T>(Func<Task<T>> action, 
                                             Func<Exception, Task> catchAction = null,
                                             System.Action finalAction = null)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var result = default(T);
            try
            {
                result =  await action().ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (catchAction == null)
                {
                    throw;
                }
                await catchAction(exception).ConfigureAwait(false);
            }
            finally
            {
                if (finalAction != null)
                {
                    finalAction();
                }
            }

            return result;
        }
    }
}