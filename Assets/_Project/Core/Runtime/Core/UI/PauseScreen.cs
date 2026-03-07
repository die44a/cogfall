using System;
using _Project.Core.Runtime.Core.Main;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Core.Runtime.Core.UI
{
    public class PauseScreen : MonoBehaviour, 
        IInitializable, 
        IResumeGameListener,
        IPauseGameListener
    {
        [SerializeField] 
        private Button resumeButton;
        
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void Show()
        {
            gameObject.SetActive(true);
            resumeButton.onClick.AddListener(_gameManager.ResumeGame);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
            resumeButton.onClick.RemoveListener(_gameManager.ResumeGame);
        }

        void IPauseGameListener.OnPauseGame()
        {
            Show();
        }
        
        void IResumeGameListener.OnResumeGame()
        {
            Hide();
        }
        
        void IInitializable.Initialize()
        {
            Hide();
        }
    }
}