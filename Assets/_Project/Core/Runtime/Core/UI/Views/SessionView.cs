using System;
using _Project.Core.Runtime.Core.GameSession;
using _Project.Core.Runtime.Core.UI.ViewModels;
using _Project.Core.Runtime.Services;
using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Core.UI.Views
{
    public class SessionView : MonoBehaviour, IDisposable
    {
        [SerializeField] private GameObject pauseMenu;
        
        private SessionViewModel _viewModel;
        private InputService _inputService;
        private bool IsPaused => _viewModel.IsPaused;

        [Inject]
        public void Construct(
            SessionViewModel viewModel,
            InputService inputService)
        {
            _viewModel = viewModel;
            _inputService = inputService;
        }

        public void Initialize()
        {
            _viewModel.StateChanged += TogglePause;
            _inputService.Pause += OnPause;
        }

        public void Dispose()
        {
            _viewModel.StateChanged -= TogglePause;
            _inputService.Pause -= OnPause;
        }

        public void OnResumeButtonClicked()
        {
            _viewModel.OnResumePressed();
        }

        public void OnExitToMainMenuButtonClicked()
        {
            _viewModel.OnExitToMenuPressed();
        }

        private void TogglePause()
        {
            pauseMenu.SetActive(IsPaused);
        }

        private void OnPause()
        {
            _viewModel.RequestPause();
        }
    }
}
