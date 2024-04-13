using CodeBase.Game;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.State
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        
        private readonly SceneLoader _sceneLoader;
        
        private readonly AllServices _services;
        
        private const string InitialSceneName = "Initial";
        
        private const string MainMenuSceneName = "MainMenu";
        
        private const string LobbySceneName = "Lobby";

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(InitialSceneName, EnterLoadLeve);
        }

        private void EnterLoadLeve() => 
            _stateMachine.Enter<LoadLevelState, string>(LobbySceneName);

        public void Exit()
        {
            Debug.Log("Exit State");
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IAssets>(new AssetProvider());
            
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>()));
        }
    }
}