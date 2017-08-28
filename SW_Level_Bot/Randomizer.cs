using System;

namespace SW_Level_Bot
{
    internal static class Randomizer
    {
        private static readonly Random Random;

        static Randomizer()
        {
            Random = new Random();
        }

        [Obsolete("Use 'FromInterval' extension method instead")]
        public static int Randomize(int interval, int value)
        {
            return Random.Next(value - interval, value + interval);
        }
    }
}