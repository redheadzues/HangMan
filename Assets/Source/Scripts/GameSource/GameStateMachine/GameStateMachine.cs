using System;
using System.Collections.Generic;

namespace Assets.Source.Scripts.GameSource.GameStateMachine
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
        private IState _activeState;

        public void AddState(IState state)
        {
            _states.Add(state.GetType(), state);
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState state = _states[typeof(TState)];
            _activeState = state;
            state.Enter();
        }
    }
}
