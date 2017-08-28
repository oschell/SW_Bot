using SW_Level_Bot.Config;
using SW_Level_Bot.Modes;

namespace SW_Level_Bot.BotStates.States
{
    internal class AfterWinState : WinLoseState
    {
        public override IState MoveNext(IButtonPositionsAndColors posColorManager, ModeConfig config, Statistics stats)
        {
            stats.Refills += StartNewRound(posColorManager, config.RefreshEnergy);
            stats.SuccessfulRuns++;
            stats.Runs++;
            stats.Print();

            return StateManager.Instance[StateKind.LastRuneFarming];
        }
    }
}