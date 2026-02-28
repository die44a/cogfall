using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Menu
{
    public class MenuInitializer : IInitializable
    {
        private readonly MenuView _menuView;
        private readonly MenuService _menuService;

        [Inject]
        public MenuInitializer(MenuView menuView, 
            MenuService menuService)
        { 
            _menuView = menuView;
            _menuService =  menuService;
            
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        public void Initialize()
        {
            _menuView.Initialize();
            _menuService.Initialize();
            
            Debug.Log("Menu initialized");
        }
    }
}
    