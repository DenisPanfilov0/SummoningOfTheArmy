using CodeBase.Config;
using CodeBase.Infrastructure.State;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Game
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private GameDeck _gameDeck;
        
        [FormerlySerializedAs("_portalPlayer")] [SerializeField] private MainPlayerConfig mainPlayer;

        public Game _game;

        private void Awake()
        {
            _game = new Game(this, _gameDeck, mainPlayer);
            
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}