using System.Drawing;

namespace SW_Level_Bot.ExtensionMethods
{
    internal static class ColorExtensions
    {
        public static bool Matches(this Color expected, Color actual, int deviation = 20)
        {
            return actual.R >= expected.R - deviation && actual.R <= expected.R + deviation
                   && actual.G >= expected.G - deviation && actual.G <= expected.G + deviation
                   && actual.B >= expected.B - deviation && actual.B <= expected.B + deviation;
        }
    }
}