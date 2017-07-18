using System;

namespace SW_Level_Bot
{
    static class Randomizer
    {
        private static Random random;

        static Randomizer()
        {
            random = new Random();
        }

        public static int Randomize(int interval, int value)
        {
            return random.Next(value - interval, value + interval);
        }
    }
}