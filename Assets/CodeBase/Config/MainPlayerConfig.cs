using UnityEngine;
using System;

namespace CodeBase.Config
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Main Player Config")]
    public class MainPlayerConfig : ScriptableObject
    {
        [SerializeField] private float _portalHealth;
        
        [SerializeField] private float _balance;

        public event Action IsBalanceChange;
        
        public float PortalHealth
        {
            get => _portalHealth;
            set => _portalHealth = value;
        }
        
        public void IncreaseBalance(float amount)
        {
            _balance += amount;
            IsBalanceChange?.Invoke();
        }
        
        public void DecreaseBalance(float amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                IsBalanceChange?.Invoke();
            }
            else
            {
                Debug.LogError("Insufficient funds!");
            }
        }

        public float GetBalance()
        {
            return _balance;
        }
    }
}