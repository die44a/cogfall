using _Project.Core.Runtime.Core.GameSession;
using Zenject;

namespace _Project.Core.Runtime.Core
{
    public class CoreInitializer : IInitializable
    {
        private readonly SessionView _view;
        private readonly SessionViewModel _viewModel;
        private readonly SessionContext _context;
        
        [Inject]
        public CoreInitializer(SessionView view,
            SessionContext context,
            SessionViewModel viewModel)
        {
            _view = view;
            _context = context;
            _viewModel = viewModel;
        }
        
        public void Initialize()
        {
            _viewModel.Initialize();
            _view.Initialize();
            _context.Initialize();
        }
    }
}
