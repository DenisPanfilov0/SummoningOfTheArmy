using CodeBase.Config;
using UnityEngine;
using UnityEngine.UI;
using CodeBase.EditorTool;
using CodeBase.Infrastructure.State;
using UnityEngine.Serialization;

namespace CodeBase
{
    public class HeroPortalHandler : MonoBehaviour
    {
        [SerializeField] private float _health;

        [SerializeField] private Slider _healthBar;

        [FormerlySerializedAs("_portalPlayer")] [SerializeField] private MainPlayerConfig mainPlayer;
        
        [SerializeField] private float _damage;

        private GameObject _endGameWindow;

        private GameStateMachine _stateMachine;

        public void Init(MainPlayerConfig mainPlayer, GameObject endGameWindow, GameStateMachine stateMachine)
        {
            this.mainPlayer = mainPlayer;
            _health = this.mainPlayer.PortalHealth;
            _healthBar.maxValue = _health;
            _healthBar.value = _health;

            _endGameWindow = endGameWindow;
            _stateMachine = stateMachine;
        }

        [Button]
        public void TakeDamage(float damage)
        {
            if (_health > damage)
            {
                _health -= damage;
            }
            else
            {
                _health = 0;
                Debug.Log("ты проиграл");
                Debug.Log("ты проиграл");
                Debug.Log("ты проиграл");
                
                
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
