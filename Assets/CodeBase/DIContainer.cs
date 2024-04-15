using CodeBase.Config;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.State;
using UnityEngine;

namespace CodeBase
{
    public class DIContainer : MonoBehaviour
    {
        public GameStateMachine StateMachine { get; private set; }

        public IAssets Assets { get; private set; }
        
        public LevelConfig CurrentLevelConfig { get; private set; }

        public MainPlayerConfig MainPlayer { get; private set; }

        public GameDeck GameDeck { get; private set; }

        public void Init(GameStateMachine stateMachine = null, IAssets assets = null, LevelConfig levelConfig = null,
            MainPlayerConfig mainPlayer = null, GameDeck gameDeck = null)
        {
            if (stateMachine != null)
            {
                StateMachine = stateMachine;
            }

            if (assets != null)
            {
                Assets = assets;
            }

            if (levelConfig != null)
            {
                CurrentLevelConfig = levelConfig;
            }
            
            if (mainPlayer != null)
            {
                MainPlayer = mainPlayer;
            }
            
            if (gameDeck != null)
            {
                GameDeck = gameDeck;
            }
            
            DontDestroyOnLoad(this);
        }

        public void Printer()
        {
            Debug.Log(StateMachine);
            Debug.Log(Assets);
            Debug.Log(CurrentLevelConfig);
            Debug.Log(MainPlayer);
        }
        
    }
}