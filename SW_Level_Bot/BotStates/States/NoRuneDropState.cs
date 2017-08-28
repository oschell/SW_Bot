using SW_Level_Bot.Config;
using SW_Level_Bot.Modes;
using Win32Library;

namespace SW_Level_Bot.BotStates.States
{
    internal class NoRuneDropState : IState
    {
        public IState MoveNext(IButtonPositionsAndColors posColorManager, ModeConfig config, Statistics stats)
        {
            //Unknown scroll, rainbowmon, mystical scroll, ...
            //sendMouseLeftclick(new Point(Randomize(90, 890), Randomize(15, 860)));
            Mouse.LeftClick(posColorManager.GetMiscButtonPos);
            ExecutionDelay.DelayFor(1500, 300);
            stats.MiscDrops++;

            return StateManager.Instance[StateKind.AfterWin];
        }
    }
}