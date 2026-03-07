using _Project.Core.Runtime.Configs;
using UnityEngine;

namespace _Project.Core.Runtime.Core.Player
{
    public class PlayerFacade : MonoBehaviour
    {
        [SerializeField] private CharacterConfig config;
        
        public PlayerModel PlayerModel { get; private set; }
        
        private void Awake()
        {
            InitializeModel();
        }

        private void InitializeModel()
        {
            if (config == null)
            {
                Debug.LogError("Player config is missing");
                return;
            }
            
            PlayerModel = new PlayerModel
            {
                MaxHealth = config.Health,
                WalkSpeed = config.WalkSpeed,
                SprintSpeed = config.SprintSpeed,
                RotationSpeed = config.RotationSpeed
            };
        }

        public void ResetState()
        {
            // Должно при респавне вовзращать все значения назад
        }
    }
}
