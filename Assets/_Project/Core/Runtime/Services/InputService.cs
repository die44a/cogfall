using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.Core.Runtime.Services
{
    public class InputService : IDisposable
    {
        private InputActions _inputActions;
        
        public event Action<Vector2> Move;
        public event Action TogglePause;

        public InputService()
        {
            _inputActions = new InputActions();
            _inputActions.Enable();

            _inputActions.Gameplay.Move.performed += ctx =>
                Move?.Invoke(ctx.ReadValue<Vector2>());

            _inputActions.Gameplay.Move.canceled += ctx =>
                Move?.Invoke(Vector2.zero);
            
            _inputActions.Gameplay.TogglePause.performed += ctx =>
                TogglePause?.Invoke();
        }

        public void Dispose()
        {
            _inputActions.Disable();
        }
    }
}