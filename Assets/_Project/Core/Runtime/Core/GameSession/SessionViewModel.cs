using System;
using Zenject;

namespace _Project.Core.Runtime.Core.GameSession
{
    public class SessionViewModel
    {
        public bool IsPaused => false;

        [Inject]
        public SessionViewModel()
        {
        }
        

        public event Action PauseStateChanged;

        public void OnResumePressed()
        {
            
        }

        public void OnExitPressed()
        {
            
        }
    }
}
