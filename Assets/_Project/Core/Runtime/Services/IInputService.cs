using System;
using UnityEngine;

namespace _Project.Core.Runtime.Services
{
    public interface IInputService
    {
        public event Action<Vector2> Move;
        public event Action Pause;
    }
}