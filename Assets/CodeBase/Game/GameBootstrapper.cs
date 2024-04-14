using CodeBase.Config;
using CodeBase.Infrastructure.State;
using UnityEngine;

namespace CodeBase.Game
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private GameDeck _gameDeck;
        
        public Game _game;

        private void Awake()
        {
            _game = new Game(this, _gameDeck);
            
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}