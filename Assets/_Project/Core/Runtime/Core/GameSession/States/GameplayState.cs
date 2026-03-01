using _Project.Core.Runtime.Services;
using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Core.GameSession.States
{
    public class GameplayState : SessionState
    {
        private SessionViewModel _sessionViewModel;
        
        public GameplayState(IFsm fsm) : base(fsm) {}

        [Inject]
        public void Construct(SessionViewModel sessionViewModel)
        {
            _sessionViewModel = sessionViewModel;
        }

        private void OnPauseRequested()
        {
            Fsm.SetState<PauseState>();
        }
        
        public override void Enter()
        {
            _sessionViewModel.PauseRequested += OnPauseRequested;
        }

        public override void Exit()
        {
            _sessionViewModel.PauseRequested -= OnPauseRequested;
        }
    }
}