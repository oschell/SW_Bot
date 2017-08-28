using System;
using SW_Level_Bot.BotStates.States;
using SW_Level_Bot.Config;

namespace SW_Level_Bot.Modes
{
    internal class BotMode
    {
        private readonly Statistics _statistics;
        private IState _currState;
        private bool _isRunning;

        public BotMode(IState startState)
        {
            _currState = startState;
            _statistics = new Statistics { StartedDate = DateTime.Now };
        }

        public void Start()
        {
            Start(null, null);
        }

        public void Start(IButtonPositionsAndColors posColorManager, ModeConfig config)
        {
            _isRunning = true;

            // Maybe add final state
            while (_currState != null && _isRunning)
            {
                _currState = _currState.MoveNext(posColorManager, config, _statistics);
            }
        }

        public void Stop()
        {
            _isRunning = false;
        }
    }
}