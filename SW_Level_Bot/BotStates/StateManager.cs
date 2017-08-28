using System;
using System.Collections.Generic;
using SW_Level_Bot.BotStates.States;

namespace SW_Level_Bot.BotStates
{
    internal class StateManager
    {
        private static StateManager _instance;
        private readonly Dictionary<StateKind, IState> _states;

        private StateManager()
        {
            _states = new Dictionary<StateKind, IState>();
            var stateFactory = new StateFactory();
            
            foreach (StateKind stateKind in Enum.GetValues(typeof(StateKind)))
            {
                _states.Add(stateKind, stateFactory.Create(stateKind));
            }
        }

        public static StateManager Instance => _instance ?? (_instance = new StateManager());

        public IState this[StateKind stateKind] => GetState(stateKind);

        public IState GetState(StateKind stateKind)
        {
            return _states.TryGetValue(stateKind, out var state)
                ? state
                : throw new ArgumentException("Mode is not implemented");
        }
    }
}