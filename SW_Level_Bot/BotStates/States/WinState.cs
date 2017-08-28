using SW_Level_Bot.Config;
using SW_Level_Bot.ExtensionMethods;
using SW_Level_Bot.Modes;
using Win32Library;

namespace SW_Level_Bot.BotStates.States
{
    internal class WinState : IState
    {
        public IState MoveNext(IButtonPositionsAndColors posColorManager, ModeConfig config, Statistics stats)
        {
            //Perform a double click
            Mouse.DoubleLeftClick(posColorManager.DoubleClickPos);
            ExecutionDelay.DelayFor(2000, 300);

            //Check whether it is a rune drop or not
            return posColorManager.CheckRuneDropCol.Matches(Screen.GetPixel(posColorManager.CheckRuneDropPos))
                ? StateManager.Instance[StateKind.RuneDrop]
                : StateManager.Instance[StateKind.NoRuneDrop];
        }
    }
}