using CodeBase.Config;
using UnityEngine;
using UnityEngine.UI;
using CodeBase.EditorTool;
using CodeBase.Infrastructure.State;

namespace CodeBase
{
    public class EnemyPortalHandler : MonoBehaviour
    {
        [SerializeField] private float _health;

        [SerializeField] private Slider _healthBar;

        [SerializeField] private LevelConfig _levelConfig;
        
        [SerializeField] private float _damage;
        
        private GameObject _endGameWindow;

        private GameStateMachine _stateMachine;

        public void Init(LevelConfig levelConfig, GameObject endGameWindow, GameStateMachine stateMachine)
        {
            _levelConfig = levelConfig;
            _health = _levelConfig.EnemyPortalHealth;
            _healthBar.maxValue = _health;
            _healthBar.value = _health;
            
            _endGameWindow = endGameWindow;

            _stateMachine = stateMachine;
        }

        [Button]
        public void TakeDamage()
        {
            if (_health > _damage)
            {
                _health -= _damage;
            }
            else
            {
                _health = 0;
                Debug.Log("Ты Выиграл этого врага");
                Debug.Log("Ты Выиграл этого врага");
                Debug.Log("Ты Выиграл этого врага");
                Debug.Log("Ты Выиграл этого врага");
                
                _endGameWindow.SetActive(true);
                EndGameHandler gameHandler = _endGameWindow.GetComponent<EndGameHandler>();
                gameHandler.Init(_stateMachine, "You Lose");
            }

            UpdateView();
        }

        private void UpdateView()
        {
            _healthBar.value = _health;
        }
    }
}