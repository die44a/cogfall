using System;

namespace _Project.Core.Runtime.Core.GameSession
{
    public interface ISessionActions 
    {
        event Action PauseRequested;
    }
}