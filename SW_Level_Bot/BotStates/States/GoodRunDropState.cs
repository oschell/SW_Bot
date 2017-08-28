using System;
using SW_Level_Bot.Config;
using SW_Level_Bot.Modes;
using SW_Level_Bot.Properties;
using Win32Library;

namespace SW_Level_Bot.BotStates.States
{
    internal class GoodRunDropState : IState
    {
        public IState MoveNext(IButtonPositionsAndColors posColorManager, ModeConfig config, Statistics stats)
        {
            //Good rune
            stats.GoodRuneCount++;
            if (stats.GoodRuneCount != null)
            {
                Screen.TakeScreenshot(Environment.ExpandEnvironmentVariables(Settings.Default.Rootpath),
                    stats.GoodRuneCount.Value);
            }

            ExecutionDelay.DelayFor(1200, 300);
            Mouse.LeftClick(posColorManager.GetRuneButtonPos);
            ExecutionDelay.DelayFor(1200, 300);

            return StateManager.Instance[StateKind.AfterWin];
        }
    }
}