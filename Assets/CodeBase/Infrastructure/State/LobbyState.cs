using CodeBase.Game;
using UnityEngine;

namespace CodeBase.Infrastructure.State
{
    public class LobbyState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly GameDeck _gameDeck;

        public LobbyState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, GameDeck gameDeck)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameDeck = gameDeck;
        }

        public void Enter()
        {
            foreach (var hero in _gameDeck.Deck)
            {
                Debug.Log(hero.Id);
            }
        }

        public void Exit()
        {

        }
    }
}