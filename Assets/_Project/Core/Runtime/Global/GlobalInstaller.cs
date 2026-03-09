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
            Container.Bind<SceneLoaderService>().AsSingle();
            Container.BindInterfacesTo<InputService>().AsSingle();
        }
    }
}
