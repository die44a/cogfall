using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Core.Player
{
    public class PlayerFactory
    {
        private readonly DiContainer _container;
        private readonly GameObject _playerPrefab;
        
        public PlayerFactory(
            DiContainer container,
            GameObject playerPrefab)
        {
            _container = container;
            _playerPrefab = playerPrefab;
        }

        public PlayerFacade Create(Transform spawnPoint)
        {
            var player = _container.InstantiatePrefabForComponent<PlayerFacade>(_playerPrefab);

            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation;

            return player;
        }
    }
}