using System;
using _Project.Core.Runtime.Core.GameSession.States;
using _Project.Core.Runtime.Services;
using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Core.GameSession
{
    public class SessionViewModel : IDisposable
    {
        private SessionContext _context;
        private SceneLoaderService _sceneLoaderService;
        public bool IsPaused => _context.CurrentState is PauseState;
        public event Action PauseRequested;
        public event Action StateChanged;

        [Inject]
        public SessionViewModel(SessionContext context,
            SceneLoaderService sceneLoaderService)
        {
            _context = context;
            _sceneLoaderService = sceneLoaderService;
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
            _sceneLoaderService.LoadMenuScene();
        }
    }
}
