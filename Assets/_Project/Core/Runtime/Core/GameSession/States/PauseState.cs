using _Project.Core.Runtime.Core.Services;
using Zenject;

namespace _Project.Core.Runtime.Core.GameSession.States
{
    public class PauseState : SessionState
    {
        private SessionService _service;
        
        public PauseState(IFsm fsm) : base(fsm) {}

        [Inject]
        public void Construct(SessionService service)
        {
            _service = service;
        }
        
        public override void Enter()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}