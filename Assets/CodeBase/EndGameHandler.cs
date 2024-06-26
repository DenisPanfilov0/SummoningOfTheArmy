using System;
using CodeBase.Infrastructure.State;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase
{
    public class EndGameHandler : MonoBehaviour
    {
        //TODO ренейминг переменной, отвечает за текст победа или поражение
        [SerializeField] private TextMeshProUGUI _text;

        [SerializeField] private Button _button;

        private GameStateMachine _stateMachine;

        public void Init(GameStateMachine stateMachine, string text)
        {
            _text.text = text;
            _stateMachine = stateMachine;
            _button.onClick.AddListener(FinishGame);
            PauseGame();
        }

        private void FinishGame()
        {
            Time.timeScale = 1f;
            _stateMachine.Enter<LoadLevelState, string>(Constants.LobbySceneName);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void PauseGame()
        {
            Time.timeScale = 0f;
        }
    }
}