using System;
using _Project.Core.Runtime.Core.GameSession;
using _Project.Core.Runtime.Core.GameSession.States;
using _Project.Core.Runtime.Services;
using Zenject;

namespace _Project.Core.Runtime.Core.UI.ViewModels
{
    public class SessionViewModel : IDisposable
    {
        private readonly SessionContext _context;
        private readonly SceneLoaderService _sceneLoaderService;
        public bool IsPaused => _context.CurrentState is PauseState;
        public event Action PauseRequested;
        public event Action StateChanged;

        [Inject]
        public SessionViewModel(
            SessionContext context,
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
        
        private void OnStateChanged(SessionState state)
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
