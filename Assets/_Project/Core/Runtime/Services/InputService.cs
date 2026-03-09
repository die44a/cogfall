using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.Core.Runtime.Services
{
    public sealed class InputService : MonoBehaviour, IInputService
    {
        public event Action<Vector2> Move;
        public event Action Pause;
        
        // Unity input action subscribe these methods 
        public void OnMove(InputAction.CallbackContext ctx)
        {
            Move?.Invoke(ctx.ReadValue<Vector2>());
            Debug.Log("Move pressed");
        }

        public void OnPause(InputAction.CallbackContext ctx)
        {
            Pause?.Invoke();
            Debug.Log("Pause pressed");
        }
    }
}