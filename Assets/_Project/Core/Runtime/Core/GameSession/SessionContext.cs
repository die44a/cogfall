using System;
using System.Collections.Generic;
using _Project.Core.Runtime.Core.GameSession.States;
using Zenject;

namespace _Project.Core.Runtime.Core.GameSession
{
    public class SessionContext : IFsm
    {
        // Add model of session in the future
        
        private readonly DiContainer _container;
        
        public SessionState CurrentState { get; private set; }
        private readonly Dictionary<Type, SessionState> _states = new ();
        public event Action<SessionState> StateChanged;
        
        [Inject]
        public SessionContext(DiContainer container)
        {
            _container = container;
        }
        
        private void AddState(SessionState state)
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

        // ReSharper disable Unity.PerformanceAnalysis
        public void Initialize()
        {
            AddState(_container.Instantiate<PauseState>());
            AddState(_container.Instantiate<GameplayState>());

            SetState<GameplayState>();
        }
    }
}
