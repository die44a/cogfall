using System;
using System.Collections.Generic;
using _Project.Core.Runtime.Core.GameSession.States;

namespace _Project.Core.Runtime.Core.GameSession
{
    public class SessionContext : IFsm
    {
        // Add model of session in the future
        
        public SessionState CurrentState { get; private set; }
        private readonly Dictionary<Type, SessionState> _states = new ();

        public event Action<SessionState> StateChanged;
        
        public void AddState(SessionState state)
            => _states.Add(state.GetType(), state);

        public void SetState<T>() where T : IState
        {
            var type = typeof(T);
        
            if (CurrentState?.GetType() == type)
                return;
            if (!_states.TryGetValue(type, out var newState))
                return;
        
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState?.Enter();
            
            StateChanged?.Invoke(CurrentState);
        }
    
        public void Update()
            => CurrentState?.Update();

        public void Initialize()
        {
            AddState(new PauseState(this));
            AddState(new GameplayState(this));

            SetState<GameplayState>();
        }
    }
}
