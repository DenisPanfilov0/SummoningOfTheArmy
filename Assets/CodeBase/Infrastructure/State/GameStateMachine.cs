using System;
using System.Collections.Generic;
using CodeBase.Config;
using CodeBase.Game;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Services;

namespace CodeBase.Infrastructure.State
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, AllServices services, GameDeck gameDeck,
            PortalPlayerConfig portalPlayer)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, services.Single<IGameFactory>()),
                [typeof(GamePlayState)] = new GamePlayState(this, services.Single<IGameFactory>(), gameDeck),
                [typeof(MainMenuState)] = new MainMenuState(this, sceneLoader, services.Single<IGameFactory>()),
                [typeof(LobbyState)] = new LobbyState(this, sceneLoader, gameDeck, services.Single<IGameFactory>(), services.Single<IAssets>(), portalPlayer),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}