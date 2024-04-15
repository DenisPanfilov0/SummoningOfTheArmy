using CodeBase.Config;
using CodeBase.Infrastructure.State;
using UnityEngine;

namespace CodeBase.Game
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private GameDeck _gameDeck;
        
        [SerializeField] private PortalPlayerConfig _portalPlayer;

        public Game _game;

        private void Awake()
        {
            _game = new Game(this, _gameDeck, _portalPlayer);
            
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}