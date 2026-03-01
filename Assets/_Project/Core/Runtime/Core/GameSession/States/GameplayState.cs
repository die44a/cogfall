using _Project.Core.Runtime.Services;
using Zenject;

namespace _Project.Core.Runtime.Core.GameSession.States
{
    public class GameplayState : SessionState
    {
        private InputService _inputService;
        
        public GameplayState(IFsm fsm) : base(fsm) {}

        [Inject]
        public void Construct(InputService inputService)
        {
            _inputService = inputService;
        }

        private void OnTogglePause()
        {
            Fsm.SetState<PauseState>();
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