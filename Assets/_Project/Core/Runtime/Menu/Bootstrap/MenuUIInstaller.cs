using _Project.Core.Runtime.Menu.UI;
using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Menu.Bootstrap
{
    public sealed class MenuUIInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuScreen mainMenuScreen;

        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MainMenuScreen>().FromInstance(mainMenuScreen);
            
            Debug.Log("Menu UI installed");
        }
    }
}