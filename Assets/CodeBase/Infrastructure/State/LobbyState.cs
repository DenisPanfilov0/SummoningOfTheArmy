using CodeBase.Game;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Services;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.State
{
    public class LobbyState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly GameDeck _gameDeck;
        private readonly IGameFactory _gameFactory;
        private readonly IAssets _assets;

        public LobbyState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, GameDeck gameDeck, IGameFactory gameFactory, IAssets assets)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameDeck = gameDeck;
            _gameFactory = gameFactory;
            _assets = assets;
        }

        public void Enter()
        {
            //TODO Разделить на методы
            GameObject container = _gameFactory.CreateDIContainer();
            DIContainer diContainer = container.GetComponent<DIContainer>();
            diContainer.Init(_gameStateMachine, _assets);
            
            GameObject canvas = _gameFactory.CreateCanvasLobby();
            TowerLevelFiller levelFiller = canvas.GetComponentInChildren<TowerLevelFiller>();
            levelFiller.Init(diContainer.StateMachine);
            levelFiller.gameObject.SetActive(false);
        }

        public void Exit()
        {

        }
    }
}