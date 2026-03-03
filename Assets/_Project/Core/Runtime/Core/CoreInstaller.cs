using _Project.Core.Runtime.Core.UI.Views;
using _Project.Core.Runtime.Core.UI.ViewModels;
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
            Container.BindInterfacesAndSelfTo<SessionContext>().AsSingle();
            Container.BindInterfacesAndSelfTo<SessionViewModel>().AsSingle();
            Container.BindInstance(sessionView).AsSingle();
            
            Container.BindInterfacesAndSelfTo<CoreInitializer>().AsSingle().NonLazy();
        }
    }
}