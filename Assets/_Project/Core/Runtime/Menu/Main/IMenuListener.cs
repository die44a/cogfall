namespace _Project.Core.Runtime.Menu.Main
{
    public interface IMenuListener
    {
    }

    public interface IGameStartListener : IMenuListener
    {
        void OnGameStart();
    }
}