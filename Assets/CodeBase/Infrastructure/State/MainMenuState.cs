using CodeBase.Game;
using CodeBase.Infrastructure.Factory;

namespace CodeBase.Infrastructure.State
{
    public class MainMenuState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;

        public MainMenuState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }


        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}