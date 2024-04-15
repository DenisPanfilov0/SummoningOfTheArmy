using UnityEngine;
using UnityEngine.UI;

namespace CodeBase
{
    public class GamePause : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
    
        private bool _isPaused = false;

        private void Start()
        {
            _pauseButton.onClick.AddListener(OnPauseButtonClick);
        }

        private void OnPauseButtonClick()
        {
            _isPaused = !_isPaused;
            TogglePause();
        }

        private void TogglePause()
        {
            if (_isPaused)
                Time.timeScale = 0f;
            else
                Time.timeScale = 1f;
        }
    }
}