using SW_Level_Bot.Config;
using SW_Level_Bot.Modes;
using Win32Library;

namespace SW_Level_Bot.BotStates.States
{
    internal class LoseState : WinLoseState
    {
        public override IState MoveNext(IButtonPositionsAndColors posColorManager, ModeConfig config, Statistics stats)
        {
            Mouse.LeftClick(posColorManager.NoContinueButtonPos);
            ExecutionDelay.DelayFor(3500, 300);
            Mouse.LeftClick(posColorManager.ReplayButtonPos);
            ExecutionDelay.DelayFor(1500, 300);

            stats.Refills += StartNewRound(posColorManager, config.RefreshEnergy);

            stats.LossCount++;
            stats.Runs++;
            stats.Print();

            return StateManager.Instance[StateKind.LastRuneFarming];
        }
    }
}