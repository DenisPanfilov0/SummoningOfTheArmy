using CodeBase.Infrastructure.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.State
{
    public class GamePlayState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        
        private readonly IGameFactory _gameFactory;
        
        public GamePlayState(GameStateMachine stateMachine, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
        }

        public void Enter(string payload)
        {
        }

        public void Exit()
        {
            Debug.Log("Exit State");
        }
    }
}