using CodeBase.Infrastructure.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.State
{
    public class GamePlayState : IState
    {
        private readonly GameStateMachine _stateMachine;
        
        private readonly IGameFactory _gameFactory;
        
        public GamePlayState(GameStateMachine stateMachine, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
        }

        public void Enter()
        {
            Debug.Log("урааааа");
            Debug.Log("урааааа");
            Debug.Log("урааааа");
            Debug.Log("урааааа");
        }

        public void Exit()
        {
        }
    }
}