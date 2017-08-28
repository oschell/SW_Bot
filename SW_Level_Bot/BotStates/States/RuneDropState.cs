using SW_Level_Bot.Config;
using SW_Level_Bot.ExtensionMethods;
using SW_Level_Bot.Modes;
using Win32Library;

namespace SW_Level_Bot.BotStates.States
{
    internal class RuneDropState : IState
    {
        public IState MoveNext(IButtonPositionsAndColors posColorManager, ModeConfig config, Statistics stats)
        {
            //Check whether it is a good rune (6* || legend)
            var isGoodRune =
                posColorManager.CheckSixStarRuneCol.Matches(Screen.GetPixel(posColorManager.CheckSixStarRunePos))
                || posColorManager.CheckLegendCol.Matches(Screen.GetPixel(posColorManager.CheckLegendPos));

            return isGoodRune
                ? StateManager.Instance[StateKind.GoodRuneDrop]
                : StateManager.Instance[StateKind.BadRuneDrop];
        }
    }
}