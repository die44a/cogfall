namespace _Project.Core.Runtime.Core.Main
{
    public interface IGameListener
    {
    }

    public interface IPauseGameListener : IGameListener
    {
        void OnPauseGame();
    }

    public interface IResumeGameListener : IGameListener
    {
        void OnResumeGame();
    }
}