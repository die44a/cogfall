using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.Core.Runtime.Core.GameSession
{
    public class SessionView : MonoBehaviour
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
            
        }
        public void ToggleView()
        {
            pauseMenu.SetActive(IsPaused);
        }

        public void OnPauseClicked(InputAction.CallbackContext context)
        {
            _viewModel.TogglePause();
        }
    }
}
