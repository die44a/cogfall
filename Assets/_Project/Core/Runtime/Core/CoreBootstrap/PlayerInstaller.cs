using _Project.Core.Runtime.Core.Player;
using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Core.CoreBootstrap
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerPrefab;
    
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.BindInstance(playerPrefab);
            
            Container.Bind<PlayerFactory>().AsSingle();
            Container.Bind<PlayerLifecycleService>().AsSingle();
        }
    }
}