using _Project.Core.Runtime.Core.Player;
using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Core.Bootstrap
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private Transform spawnPoint;
    
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.BindInstance(playerPrefab);
            
            Container.Bind<PlayerFactory>().AsSingle();
            Container.BindInstance(new SpawnPoint(spawnPoint)).AsSingle();
            Container.Bind<PlayerLifecycleService>().AsSingle();
        }
    }
}