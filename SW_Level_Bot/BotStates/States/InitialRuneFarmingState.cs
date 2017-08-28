using SW_Level_Bot.Config;
using SW_Level_Bot.ExtensionMethods;
using SW_Level_Bot.Modes;
using Win32Library;

namespace SW_Level_Bot.BotStates.States
{
    internal class InitialRuneFarmingState : IState
    {
        public IState MoveNext(IButtonPositionsAndColors posColorManager, ModeConfig config, Statistics stats)
        {
            //Win condition - Check reward color and a pixel in the middle
            if (posColorManager.WinCondition1Col.Matches(Screen.GetPixel(posColorManager.WinCondition1Pos)) &&
                posColorManager.WinCondition2Col.Matches(Screen.GetPixel(posColorManager.WinCondition2Pos)))
            {
                return StateManager.Instance[StateKind.Win];
            }
            //Lose condition
            if (posColorManager.LoseCondition1Col.Matches(Screen.GetPixel(posColorManager.LoseCondition1Pos)) &&
                posColorManager.LoseCondition2Col.Matches(Screen.GetPixel(posColorManager.LoseCondition2Pos)))
            {
                return StateManager.Instance[StateKind.Lose];
            }
            //Network problems - send data again
            if (posColorManager.NetworkProblems1Col.Matches(
                    Screen.GetPixel(posColorManager.NetworkProblems1Pos)) &&
                posColorManager.NetworkProblems2Col.Matches(Screen.GetPixel(posColorManager.NetworkProblems2Pos)))
            {
                return StateManager.Instance[StateKind.NetworkProblem];
            }
            //Unstable network connection
            if (posColorManager.UnstableConnection1Col.Matches(
                    Screen.GetPixel(posColorManager.UnstableConnection1Pos)) &&
                posColorManager.UnstableConnection1Col.Matches(Screen.GetPixel(posColorManager.UnstableConnection2Pos)))
            {
                return StateManager.Instance[StateKind.UnstableNetwork];
            }

            return StateManager.Instance[StateKind.LastRuneFarming];
        }
    }
}