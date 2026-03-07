using _Project.Core.Runtime.Configs;

namespace _Project.Core.Runtime.Core.Player
{
    public class PlayerModel
    {
        public bool IsAlive { get; set; }
        public float CurrentHealth { get;  set; }
        public float MaxHealth { get; set; }
        public float RotationSpeed { get; set; }
        public float WalkSpeed { get; set; }
        public float SprintSpeed { get; set; }
    }
}
