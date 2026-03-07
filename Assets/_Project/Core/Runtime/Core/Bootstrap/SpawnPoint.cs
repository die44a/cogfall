using UnityEngine;

namespace _Project.Core.Runtime.Core.Bootstrap
{
    public class SpawnPoint
    {
        public Transform Transform;

        public SpawnPoint(Transform transform)
        {
            Transform = transform;
        }
    }
}