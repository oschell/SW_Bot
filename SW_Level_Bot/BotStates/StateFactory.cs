using System;
using System.Collections.Generic;
using SW_Level_Bot.BotStates.States;

namespace SW_Level_Bot.BotStates
{
    internal class StateFactory : AbstractFactory<StateKind, IState>
    {
        public StateFactory()
        {
            Dict = new Dictionary<StateKind, Func<IState>>
            {
                { StateKind.AfterWin, () => new AfterWinState() },
                { StateKind.BadRuneDrop, () => new BadRunDropState() },
                { StateKind.Debug, () => new DebugState() },
                { StateKind.GoodRuneDrop, () => new GoodRunDropState() },
                { StateKind.InitialRuneFamring, () => new InitialRuneFarmingState() },
                { StateKind.LastRuneFarming, () => new LastRuneFarmingState() },
                { StateKind.Lose, () => new LoseState() },
                { StateKind.NetworkProblem, () => new NetworkProblemsState() },
                { StateKind.None, () => null }, // TODO: maybe change to final state
                { StateKind.NoRuneDrop, () => new NoRuneDropState() },
                { StateKind.RuneDrop, () => new RuneDropState() },
                { StateKind.UnstableNetwork, () => new UnstableNetworkState() },
                { StateKind.Win, () => new WinState() }
            };
        }

        protected override Dictionary<StateKind, Func<IState>> Dict { get; }
    }
}