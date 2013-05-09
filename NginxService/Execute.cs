using System;
using System.Threading;

namespace NginxService
{
    public static class Execute
    {
        public static void UntilTrueOrTimeout(Func<bool> func, int retryCount, TimeSpan interval)
        {
            int retries = 0;
            while (!func() && retries < retryCount)
            {
                Thread.Sleep(interval);
                retries++;
            }
        }
    }
}