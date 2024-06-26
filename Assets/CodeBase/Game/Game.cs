using CodeBase.Config;
using CodeBase.Infrastructure.State;
using CodeBase.Services;

namespace CodeBase.Game
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, GameDeck gameDeck, MainPlayerConfig mainPlayer)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container, gameDeck, mainPlayer);
        }
    }
}