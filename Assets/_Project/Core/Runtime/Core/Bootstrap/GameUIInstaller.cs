using _Project.Core.Runtime.Core.Main;
using _Project.Core.Runtime.Core.UI;
using UnityEngine;
using Zenject;
// ReSharper disable Unity.PerformanceCriticalCodeInvocation

namespace _Project.Core.Runtime.Core.Bootstrap
{
    public class GameUIInstaller : MonoInstaller
    {
        [SerializeField] PauseScreen pauseScreen;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PauseScreen>().FromInstance(pauseScreen);
            
            Debug.Log("Game UI installed");
        }
    }
}