using CodeBase.Config;
using CodeBase.Infrastructure.Factory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.State
{
    public class GamePlayState : IState
    {
        private readonly GameStateMachine _stateMachine;
        
        private readonly IGameFactory _gameFactory;
        
        public GamePlayState(GameStateMachine stateMachine, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
        }

        public void Enter()
        {
            LevelConfig config = GameObject.FindObjectOfType<DIContainer>().CurrentLevelConfig;
            
            //GameObject canvas = _gameFactory.CreateCanvasLobby();
            
            Debug.Log($"Урааа, мы перешли на уровень {config}");
            Debug.Log($"Урааа, мы перешли на уровень {config}");
            Debug.Log($"Урааа, мы перешли на уровень {config}");
            Debug.Log($"Урааа, мы перешли на уровень {config}");
        }

        public void Exit()
        {
        }
    }
}