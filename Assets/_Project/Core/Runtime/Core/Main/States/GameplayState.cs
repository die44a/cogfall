using _Project.Core.Runtime.Core.UI.ViewModels;
using _Project.Core.Runtime.Services;
using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Core.GameSession.States
{
    public class GameplayState : SessionState
    {
        private ISessionActions _sessionActions;
        
        public GameplayState(IFsm fsm) : base(fsm) {}

        [Inject]
        public void Construct(ISessionActions sessionViewModel)
        {
            _sessionActions = sessionViewModel;
        }

        private void OnPauseRequested()
        {
            Fsm.SetState<PauseState>();
        }
        
        public override void Enter()
        {
            _sessionActions.PauseRequested += OnPauseRequested;
        }

        public override void Exit()
        {
            _sessionActions.PauseRequested -= OnPauseRequested;
        }
    }
}