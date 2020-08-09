using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Core
{

    public static class AsyncAwaiter
    {

        private static SemaphoreSlim SelfLock = new SemaphoreSlim(1, 1);

        private static Dictionary<string, SemaphoreSlim> Semaphores = new Dictionary<string, SemaphoreSlim>();

        public static async Task<T> AwaitResultAsync<T>(string key, Func<Task<T>> task, int maxAccessCount = 1)
        {
            await SelfLock.WaitAsync();

            try
            {
                if (!Semaphores.ContainsKey(key))
                    Semaphores.Add(key, new SemaphoreSlim(maxAccessCount, maxAccessCount));
            }
            finally
            {

                SelfLock.Release();
            }

            var semaphore = Semaphores[key];

            await semaphore.WaitAsync();

            try
            {
                return await task();
            }
            finally
            {
                semaphore.Release();
            }
        }

        public static async Task AwaitAsync(string key, Func<Task> task, int maxAccessCount = 1)
        {

            await SelfLock.WaitAsync();

            try
            {
                if (!Semaphores.ContainsKey(key))
                    Semaphores.Add(key, new SemaphoreSlim(maxAccessCount, maxAccessCount));
            }
            finally
            {

                SelfLock.Release();
            }

            var semaphore = Semaphores[key];

            await semaphore.WaitAsync();

            try
            {
                await task();
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                throw;
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}