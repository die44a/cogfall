using _Project.Core.Runtime.Services;
using Zenject;

namespace _Project.Core.Runtime.Core.GameSession.States
{
    public class PauseState : SessionState
    {
        private SessionViewModel _sessionViewModel;
        
        public PauseState(IFsm fsm) : base(fsm) {}

        [Inject]
        public void Construct(SessionViewModel sessionViewModel)
        {
            _sessionViewModel = sessionViewModel;
        }

        private void OnPauseRequested()
        {
            Fsm.SetState<GameplayState>();
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