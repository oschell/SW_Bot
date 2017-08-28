using System;

namespace SW_Level_Bot.ExtensionMethods
{
    internal static class RandomExtensions
    {
        public static int FromInterval(this Random random, int interval, int value)
        {
            return random.Next(value - interval, value + interval);
        }
    }
}