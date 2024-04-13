using CodeBase.Game;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.State
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        
        private readonly SceneLoader _sceneLoader;
        
        private readonly IGameFactory _gameFactory;
        
        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter(string payload) => 
            _sceneLoader.Load(payload, () => OnLoaded(payload));

        public void Exit()
        {
            Debug.Log("Exit State");
        }

        private void OnLoaded(string payload)
        {
            if (payload == "Lobby")
            {
                _stateMachine.Enter<LobbyState>();
            }
            else if (payload == "GamePlay")
            {
                _stateMachine.Enter<GamePlayState>();
            }
        }
    }
}