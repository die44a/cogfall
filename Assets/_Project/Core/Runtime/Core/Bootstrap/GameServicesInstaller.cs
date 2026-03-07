using _Project.Core.Runtime.Core.Main;
using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Core.CoreBootstrap
{
    public class GameServicesInstaller : MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
            
            Debug.Log("Game services installed");
        }
    }
}