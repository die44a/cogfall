using UnityEngine;

namespace _Project.Core.Runtime.Configs
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Scriptable Objects/CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        public float Health;
        public float WalkSpeed;
        public float SprintSpeed;
        public float RotationSpeed;
    }
}
