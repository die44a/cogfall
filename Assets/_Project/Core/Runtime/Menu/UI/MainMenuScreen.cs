using _Project.Core.Runtime.Menu.Main;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Core.Runtime.Menu.UI
{
    public class MainMenuScreen : MonoBehaviour, IGameStartListener
    {
        [SerializeField] private Button startButton;

        private MenuManager _menuManager;

        [Inject]
        public void Construct(MenuManager menuManager)
        {
            _menuManager = menuManager;
            gameObject.SetActive(true);
        }
        
        void IGameStartListener.OnGameStart()
        {
            
        }

        private void Awake()
        {
            startButton.onClick.AddListener(_menuManager.StartGame);
        }

        private void OnDestroy()
        {
            startButton.onClick.RemoveListener(_menuManager.StartGame);
        }
    }
}
