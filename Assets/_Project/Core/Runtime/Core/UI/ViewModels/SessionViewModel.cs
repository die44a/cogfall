using System;
using _Project.Core.Runtime.Core.GameSession;
using _Project.Core.Runtime.Core.GameSession.States;
using _Project.Core.Runtime.Core.Player;
using _Project.Core.Runtime.Services;
using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Core.UI.ViewModels
{
    public class SessionViewModel : ISessionActions, IDisposable
    {
        private readonly SessionContext _context;
        private readonly SceneLoaderService _sceneLoaderService;
        
        // TODO: Подумать, куда перенести при рефакторинге
        private readonly PlayerLifecycleService _playerLifecycleService;
        
        public bool IsPaused => _context.CurrentState is PauseState;
        public event Action PauseRequested;
        public event Action StateChanged;

        public SessionViewModel(
            SessionContext context,
            SceneLoaderService sceneLoaderService,
            PlayerLifecycleService playerLifecycleService)
        {
            _context = context;
            _sceneLoaderService = sceneLoaderService;
            _playerLifecycleService = playerLifecycleService;
        }

        public void StartGame()
        {
            _playerLifecycleService.SpawnPlayer();
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
