using CodeBase.Config;
using CodeBase.EditorTool;
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

        public void Init(GameStateMachine stateMachine = null, IAssets assets = null, LevelConfig levelConfig = null)
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
            
            DontDestroyOnLoad(this);
        }

        [Button]
        public void Printer()
        {
            Debug.Log(StateMachine);
            Debug.Log(Assets);
            Debug.Log(CurrentLevelConfig);
        }
        
    }
}