using SW_Level_Bot.Config;
using SW_Level_Bot.Modes;
using Win32Library;

namespace SW_Level_Bot.BotStates.States
{
    internal class BadRunDropState : IState
    {
        public IState MoveNext(IButtonPositionsAndColors posColorManager, ModeConfig config, Statistics stats)
        {
            //Bad rune
            stats.BadRuneCount++;
            //Purple 5* rune: take screenshot in order to check the sell heuristic quality
            //if ((checkRuneName(230, 130, 237) && MatchedColor(221, 228, 226, GetPixel(new Point(657, 366)))))
            //    take_screenshot(SUBPATH, bad_rune_count);
            Mouse.LeftClick(posColorManager.SellRuneButtonPos);
            ExecutionDelay.DelayFor(1200, 300);
            //Is it a 5* or violet rune? Confirm sell button
            Mouse.LeftClick(posColorManager.ConfirmSellRuneButtonPos);
            ExecutionDelay.DelayFor(3500, 300);

            return StateManager.Instance[StateKind.AfterWin];
        }
    }
}