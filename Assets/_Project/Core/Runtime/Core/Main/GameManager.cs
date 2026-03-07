using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Core.Main
{
    public sealed class GameManager : IInitializable
    {
        public event Action OnPauseGame;
        public event Action OnResumeGame;
        
        public GameState State { get; private set; }
        private List<IGameListener> _listeners = new();
        
        public void AddListerner(IGameListener listener)
            => _listeners.Add(listener);
        
        public void RemoveListerner(IGameListener listener)
            => _listeners.Remove(listener);

        public void PauseGame()
        {
            foreach (var listener in _listeners)
                if (listener is IPauseGameListener  startGameListener)
                    startGameListener.OnPauseGame();
            
            OnPauseGame?.Invoke();
            
            Debug.Log("Game Paused");
        }

        public void ResumeGame()
        {
            foreach (var listener in _listeners)
                if (listener is IResumeGameListener  startGameListener)
                    startGameListener.OnResumeGame();
            
            OnResumeGame?.Invoke();
            
            Debug.Log("Game Resumed");
        }

        void IInitializable.Initialize()
        {
            State = GameState.PLAY;
            
            Debug.Log("Game Manager initialized");
        }
    }
}