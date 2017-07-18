using System;
using System.Drawing;

namespace SW_Level_Bot
{
    static class ColorExtensions
    {
        public static bool Matches(this Color expected, Color actual)
        {
            const int range = 20;
            return actual.R >= expected.R - range && actual.R <= expected.R + range
                && actual.G >= expected.G - range && actual.G <= expected.G + range
                && actual.B >= expected.B - range && actual.B <= expected.B + range;
        }
    }
}