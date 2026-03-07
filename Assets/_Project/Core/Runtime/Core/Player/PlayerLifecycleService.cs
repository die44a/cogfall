using System;
using _Project.Core.Runtime.Core.Bootstrap;
using UnityEngine;

namespace _Project.Core.Runtime.Core.Player
{
    public class PlayerLifecycleService
    {
        private readonly PlayerFactory _playerFactory;
        private PlayerFacade _player;
        
        // TODO: Delete after level system will be created
        private SpawnPoint _spawnPoint;
        
        public PlayerLifecycleService(PlayerFactory playerFactory,
            SpawnPoint spawnPoint)
        {
            _playerFactory = playerFactory;
            _spawnPoint = spawnPoint;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void SpawnPlayer()
        {
            if (_player != null)
            {
                Debug.LogWarning("Player is spawned already");
                return;
            }
            
            _player = _playerFactory.Create(_spawnPoint.Transform);
        }

        public void RespawnPlayer()
        {
            if (_player == null)
            {
                SpawnPlayer();
                return;
            }
            
            _player.transform.position = _spawnPoint.Transform.position;
            _player.transform.rotation = _spawnPoint.Transform.rotation;
            _player.ResetState();
        }
    }
}