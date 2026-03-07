using _Project.Core.Runtime.Menu.Main;
using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Menu.Bootstrap
{
    public class MenuCoreInstaller : MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MenuManager>().AsSingle().NonLazy();
            
            Debug.Log("Menu service installed");
        }
    }
}
