using System;
using System.Collections.Generic;
using SW_Level_Bot.BotStates;

namespace SW_Level_Bot.Modes
{
    internal class ModeFactory : AbstractFactory<Mode, BotMode>
    {
        public ModeFactory()
        {
            Dict = new Dictionary<Mode, Func<BotMode>>
            {
                { Mode.GeneralFarming, () => new BotMode(StateManager.Instance[StateKind.InitialRuneFamring]) },
                { Mode.Debug, () => new BotMode(StateManager.Instance[StateKind.Debug]) },
                { Mode.Exit, () => new BotMode(StateManager.Instance[StateKind.None]) }
            };
        }

        protected override Dictionary<Mode, Func<BotMode>> Dict { get; }
    }
}