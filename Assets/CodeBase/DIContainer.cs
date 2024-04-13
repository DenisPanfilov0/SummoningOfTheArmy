using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.State;
using UnityEngine;

namespace CodeBase
{
    public class DIContainer : MonoBehaviour
    {
        public GameStateMachine StateMachine { get; private set; }

        public IAssets Assets { get; private set; }

        public void Init(GameStateMachine stateMachine, IAssets assets)
        {
            StateMachine = stateMachine;
            Assets = assets;
        }
    }
}