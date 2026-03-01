public interface IFsm
{
    void SetState<T>() where T : IState;
}
