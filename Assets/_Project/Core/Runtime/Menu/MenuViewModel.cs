using System;
using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Menu
{
    public class MenuViewModel
    {
        private MenuModel _menuModel;
        private MenuView _menuView;

        [Inject]
        private void Construct(MenuModel menuModel, 
            MenuView menuView)
        {
            _menuModel = menuModel;
            _menuView = menuView;
        }
        
        public Action StartButtonClicked { get; set; }
        public Action ExitButtonClicked { get; set; }
        
        public void HandleStartButtonClick()
        {
            Debug.Log("Start button click");
            StartButtonClicked?.Invoke();
        }

        public void HandleExitButtonClick()
        {
            Debug.Log("Exit button click");
            ExitButtonClicked?.Invoke();
        }
    }
}
