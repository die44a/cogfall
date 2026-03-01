using System;
using _Project.Core.Runtime.Core.GameSession.States;
using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Core.GameSession
{
    public class SessionViewModel : IDisposable
    {
        private SessionContext _context;
        public bool IsPaused => _context.CurrentState is PauseState;
        public event Action PauseRequested;
        public event Action StateChanged;

        [Inject]
        public SessionViewModel(SessionContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.StateChanged += OnStateChanged;
        }

        public void Dispose()
        {
         _context.StateChanged -= OnStateChanged;   
        }
        
        public void OnStateChanged(SessionState state)
        {
            StateChanged?.Invoke();
        }

        public void RequestPause()
        {
            PauseRequested?.Invoke();
        }
        
        public void OnResumePressed()
        {
            PauseRequested?.Invoke();
        }

        public void OnExitToMenuPressed()
        {
        }
    }
}
