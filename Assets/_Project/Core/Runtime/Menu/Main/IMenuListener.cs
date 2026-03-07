namespace _Project.Core.Runtime.Menu.Main
{
    public interface IMenuListener
    {
    }

    public interface IStartGameListener : IMenuListener
    {
        void OnGameStart();
    }
}