namespace _Project.Core.Runtime.Core.GameSession.States
{
    public abstract class SessionState : IState
    {
        protected readonly IFsm Fsm;

        protected SessionState(IFsm fsm)
            => Fsm = fsm;

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
