using SW_Level_Bot.Config;
using SW_Level_Bot.Modes;
using Win32Library;

namespace SW_Level_Bot.BotStates.States
{
    internal class NetworkProblemsState : IState
    {
        public IState MoveNext(IButtonPositionsAndColors posColorManager, ModeConfig config, Statistics stats)
        {
            Mouse.LeftClick(posColorManager.SendDataAgainButtonPos);

            return StateManager.Instance[StateKind.LastRuneFarming];
        }
    }
}