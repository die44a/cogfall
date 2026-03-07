using UnityEngine;

namespace _Project.Core.Runtime.Core.CoreBootstrap
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