using _Project.Core.Runtime.Core.UI.ViewModels;
using _Project.Core.Runtime.Services;
using Zenject;

namespace _Project.Core.Runtime.Core.GameSession.States
{
    public class PauseState : SessionState
    {
        private ISessionActions _sessionActions;
        
        public PauseState(IFsm fsm) : base(fsm) {}

        [Inject]
        public void Construct(ISessionActions sessionViewModel)
        {
            _sessionActions = sessionViewModel;
        }

        private void OnPauseRequested()
        {
            Fsm.SetState<GameplayState>();
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