using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.Core.Runtime.Core.GameSession
{
    public class SessionView : MonoBehaviour, IDisposable
    {
        [SerializeField] private GameObject pauseMenu;
        
        private SessionViewModel _viewModel;
        private bool IsPaused => _viewModel.IsPaused;

        [Inject]
        public void Construct(SessionViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Initialize()
        {
            _viewModel.PauseStateChanged += OnTogglePause;
        }

        public void Dispose()
        {
            _viewModel.PauseStateChanged -= OnTogglePause;
        }

        public void OnResumeButtonClicked()
        {
            _viewModel.OnResumePressed();
        }

        public void OnExitToMainMenuButtonClicked()
        {
            _viewModel.OnExitPressed();
        }
        
        public void OnTogglePause()
        {
            pauseMenu.SetActive(IsPaused);
        }
    }
}
