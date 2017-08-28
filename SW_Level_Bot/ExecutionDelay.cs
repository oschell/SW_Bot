using System;
using System.Threading;
using SW_Level_Bot.ExtensionMethods;

namespace SW_Level_Bot
{
    internal static class ExecutionDelay
    {
        private static readonly Random Random = new Random();

        public static void DelayFor(int milliseconds)
        {
            DelayFor(milliseconds, 0);
        }

        public static void DelayFor(int milliseconds, int deviation)
        {
            Thread.Sleep(Random.FromInterval(milliseconds, deviation));
            //Task.Delay(Random.FromInterval(milliseconds, deviation)).Wait();
        }
    }
}