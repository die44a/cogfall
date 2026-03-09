using _Project.Core.Runtime.Services;
using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Global
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private InputService inputService;
        
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.Bind<IInputService>().FromInstance(inputService).AsSingle();
            Container.BindInterfacesAndSelfTo<SceneLoaderService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<InputService>().AsSingle();
        }
    }
}
