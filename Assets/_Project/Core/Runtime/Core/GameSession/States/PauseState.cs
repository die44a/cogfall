using _Project.Core.Runtime.Services;
using Zenject;

namespace _Project.Core.Runtime.Core.GameSession.States
{
    public class PauseState : SessionState
    {
        private InputService _inputService;
        
        public PauseState(IFsm fsm) : base(fsm) {}

        [Inject]
        public void Construct(InputService inputService)
        {
            _inputService = inputService;
        }

        private void OnTogglePause()
        {
            Fsm.SetState<GameplayState>();
        }
        
        public override void Enter()
        {
            _inputService.TogglePause += OnTogglePause;
        }

        public override void Exit()
        {
            _inputService.TogglePause -= OnTogglePause;
        }
    }
}