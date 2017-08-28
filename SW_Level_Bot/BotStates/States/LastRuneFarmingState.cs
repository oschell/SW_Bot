using SW_Level_Bot.Config;
using SW_Level_Bot.Modes;

namespace SW_Level_Bot.BotStates.States
{
    internal class LastRuneFarmingState : IState
    {
        public IState MoveNext(IButtonPositionsAndColors posColorManager, ModeConfig config, Statistics stats)
        {
            ExecutionDelay.DelayFor(1500);

            return StateManager.Instance[StateKind.InitialRuneFamring];
        }
    }
}