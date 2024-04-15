using CodeBase.Config;
using TMPro;
using UnityEngine;

namespace CodeBase
{
    public class BalanceUI : MonoBehaviour
    {
        [SerializeField] private MainPlayerConfig _mainPlayerConfig;

        [SerializeField] private TextMeshProUGUI _balance;
        
        private void Start()
        {
            _mainPlayerConfig = FindObjectOfType<DIContainer>().MainPlayer;
            _mainPlayerConfig.IsBalanceChange += ChangeBalanceUI;
            SetBalanceUI();
        }

        private void ChangeBalanceUI()
        {
            SetBalanceUI();
        }

        private void SetBalanceUI()
        {
            _balance.text = _mainPlayerConfig.GetBalance().ToString();
        }
    }
}