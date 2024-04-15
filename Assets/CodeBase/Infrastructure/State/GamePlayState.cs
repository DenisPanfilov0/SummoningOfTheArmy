using CodeBase.Config;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.State
{
    public class GamePlayState : IState
    {
        private readonly GameStateMachine _stateMachine;
        
        private readonly IGameFactory _gameFactory;

        private readonly GameDeck _gameDeck;
        
        public GamePlayState(GameStateMachine stateMachine, IGameFactory gameFactory, GameDeck gameDeck)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
            _gameDeck = gameDeck;
        }

        public void Enter()
        {
            DIContainer diContainer = GameObject.FindObjectOfType<DIContainer>();
            LevelConfig config = diContainer.CurrentLevelConfig;
            PortalPlayerConfig portalPlayer = diContainer.PortalPlayer;
            
            GameObject canvas = _gameFactory.CreateCanvasGamePlay();
            UIController uiController = canvas.GetComponent<UIController>();

            GameObject endGameWindow = _gameFactory.CreateObject(AssetPath.EndGameWindowPath, canvas.transform);

            GameObject heroPortal = _gameFactory.CreateObject(AssetPath.HeroPortalPath, canvas.transform);
            heroPortal.GetComponent<HeroPortalHandler>().Init(portalPlayer, endGameWindow, _stateMachine);

            GameObject enemyPortal = _gameFactory.CreateObject(AssetPath.EnemyPortalPath, canvas.transform);
            enemyPortal.GetComponent<EnemyPortalHandler>().Init(config, endGameWindow, _stateMachine);
            
            GameObject heroSlotsMenu = _gameFactory.CreateObject(AssetPath.HeroSlotsMenuPath, canvas.transform);
            
            GameObject heroSpawnPoints = _gameFactory.CreateObject(AssetPath.HeroSpawnPointPath, canvas.transform);
            GameObject enemySpawnPoints = _gameFactory.CreateObject(AssetPath.EnemySpawnPointPath, canvas.transform);
            
            uiController.InitSpawnPoint(heroSpawnPoints.transform, enemySpawnPoints.transform, config);

            foreach (var hero in _gameDeck.Deck)
            {
                GameObject obj = _gameFactory.CreateObject(AssetPath.HeroSlotPath, heroSlotsMenu.transform);
                Button spawnButton = obj.GetComponent<Button>();
                uiController.AddListenerButton(spawnButton, hero);
            }
            
            
            
            endGameWindow.transform.SetAsLastSibling();
            
            Debug.Log($"Урааа, мы перешли на уровень {config}");
            Debug.Log($"Урааа, мы перешли на уровень {config}");
            Debug.Log($"Урааа, мы перешли на уровень {config}");
            Debug.Log($"Урааа, мы перешли на уровень {config}");
        }

        public void Exit()
        {
        }
    }
}