using CodeBase.Config;
using CodeBase.Infrastructure.State;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Game
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private GameDeck _gameDeck;
        
        [SerializeField] private MainPlayerConfig mainPlayer;
        
        private const string GameVersionKey = "GameVersion";

        public Game _game;

        private void Awake()
        {
            mainPlayer.LoadData(mainPlayer.name);
            
            CheckGameVersion();

            _game = new Game(this, _gameDeck, mainPlayer);
            
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }

        private void CheckGameVersion()
        {
            string currentGameVersion = Application.version;

            string savedVersion = PlayerPrefs.GetString(currentGameVersion, "");

            if (savedVersion != currentGameVersion)
            {
                PlayerPrefs.DeleteAll();
                PlayerPrefs.SetString(currentGameVersion, currentGameVersion);
                PlayerPrefs.Save();
            }
        }
    }
}