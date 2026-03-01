using Zenject;

namespace _Project.Core.Runtime.Core
{
    public class CoreInstaller : MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
        
            Container.BindInterfacesAndSelfTo<CoreInitializer>().AsSingle().NonLazy();
        }
    }
}
