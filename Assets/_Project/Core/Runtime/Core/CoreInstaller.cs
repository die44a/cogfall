using _Project.Core.Runtime.Core.GameSession;
using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Core
{
    public class CoreInstaller : MonoInstaller
    {
        [SerializeField] private SessionView sessionView;
        
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.BindInstance(sessionView).AsSingle();
            Container.Bind<SessionContext>().AsSingle();
            Container.Bind<SessionView>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CoreInitializer>().AsSingle().NonLazy();
        }
    }
}