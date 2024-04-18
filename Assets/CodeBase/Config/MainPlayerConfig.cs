using UnityEngine;
using System;

namespace CodeBase.Config
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Main Player Config")]
    public class MainPlayerConfig : ScriptableObject
    {
        [SerializeField] private float _portalHealth;
        
        [SerializeField] private float _balance;

        [SerializeField] private float _maxManaPool;
        
        [SerializeField] private float _startManaPool;

        [SerializeField] private float _manaRegeneration;

        public event Action IsBalanceChange;
        
        public float MaxManaPool
        {
            get => _maxManaPool;
            set => _maxManaPool = value;
        }
        
        public float StartManaPool
        {
            get => _startManaPool;
            set => _startManaPool = value;
        }
        
        public float ManaRegeneration
        {
            get => _manaRegeneration;
            set => _manaRegeneration = value;
        }
        
        public float PortalHealth
        {
            get => _portalHealth;
            set => _portalHealth = value;
        }
        
        public void IncreaseBalance(float amount)
        {
            _balance += amount;
            IsBalanceChange?.Invoke();
            SaveData();
        }
        
        public bool DecreaseBalance(float amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                IsBalanceChange?.Invoke();
                SaveData();
            }
            else
            {
                return false;
            }

            return true;
        }

        public float GetBalance()
        {
            return _balance;
        }
        
        public void SaveData()
        {
            SaveManager.SaveData(this, name);
        }

        public void LoadData(string stringKey)
        {
            SaveManager.LoadData(this, stringKey);
        }
    }
}