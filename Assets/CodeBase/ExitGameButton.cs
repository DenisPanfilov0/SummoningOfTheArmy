using CodeBase.Infrastructure.State;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase
{
    public class ExitGameButton : MonoBehaviour
    {
        [SerializeField] private Button _exitGame;
        [SerializeField] private GameStateMachine _stateMachine;

        private void Start()
        {
            _stateMachine = FindObjectOfType<DIContainer>().StateMachine;
            _exitGame.onClick.AddListener(ExitGame);
        }

        private void OnDestroy()
        {
            _exitGame.onClick.RemoveAllListeners();
        }

        private void ExitGame()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;

            if (currentSceneName == "GamePlay")
            {
                _stateMachine.Enter<LoadLevelState, string>(Constants.LobbySceneName);
            }
            else if (currentSceneName == "Lobby")
            {
                Application.Quit();
            }
        }
    }
}