using _Project.Core.Runtime.Services;
using Zenject;

namespace _Project.Core.Runtime.Bootstrap
{
    public class BootstrapInitializer : IInitializable
    {
        private readonly SceneLoaderService _sceneLoaderService;
        private readonly InputService _inputService;

        public BootstrapInitializer(SceneLoaderService sceneLoaderService,
            InputService inputService)
        {
            _sceneLoaderService = sceneLoaderService;
            _inputService = inputService;
        }

        public void Initialize()
        {
            // Init services
            _sceneLoaderService.Initialize();
            
            // Do something else
            _sceneLoaderService.LoadMenuScene();
        }
    }
}