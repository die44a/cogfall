using System;
using UnityEngine;

namespace _Project.Core.Runtime.Core.Player
{
    public class PlayerLifecycleService
    {
        private readonly PlayerFactory _playerFactory;
        private PlayerFacade _player;
        
        public PlayerLifecycleService(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public void Spawn(Transform spawnPoint)
        {
            if (_player != null)
            {
                Debug.LogWarning("Player is spawned already");
                return;
            }
            
            _player = _playerFactory.Create(spawnPoint);
        }

        public void Respawn(Transform spawnPoint)
        {
            if (_player == null)
            {
                Spawn(spawnPoint);
                return;
            }
            
            _player.transform.position = spawnPoint.position;
            _player.transform.rotation = spawnPoint.rotation;
            _player.ResetState();
        }
    }
}