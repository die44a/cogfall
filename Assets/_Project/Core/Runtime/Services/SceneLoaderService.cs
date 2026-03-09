using UnityEngine;
using Zenject;

namespace _Project.Core.Runtime.Services
{
    public sealed class SceneLoaderService : IInitializable
    {
        private ZenjectSceneLoader _sceneLoader;
    
        [Inject]
        private void Construct(ZenjectSceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public void LoadMenuScene()
        {
            _sceneLoader.LoadScene("1.Menu");
        }

        public void LoadCoreScene()
        {
            _sceneLoader.LoadScene("2.Core");
        }

        public void Initialize()
        {
            LoadMenuScene();
            Debug.Log("Scene Loaded");
        }
    }
}
