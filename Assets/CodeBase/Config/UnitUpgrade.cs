using UnityEngine;
using CodeBase.EditorTool;

namespace CodeBase.Config
{
    [CreateAssetMenu(fileName = "UnitUpgrade", menuName = "Configs/Unit Upgrade")]
    public class UnitUpgrade : ScriptableObject
    {
        [SerializeField] private int _currenUpgradeLevel;
        [SerializeField] private int _maxUpgradeLevel;
        [SerializeField] private float _priceItem;
        [SerializeField] private float _priceModifier;

        public int MaxUpgradeLevel => _maxUpgradeLevel;
        public float PriceModifier => _priceModifier;

        public int CurrenUpgradeLevel
        {
            get => _currenUpgradeLevel;
            set => _currenUpgradeLevel = value;
        }

        public float PriceItem
        {
            get => _priceItem;
            set => _priceItem = value;
        }

        [SerializeField] private bool _isUnitUpgrade;
        [SerializeField] private bool _isAccountUpgrade;
        [SerializeField] private bool _isUnlockUnit;

        [ConditionalHide("_isUnitUpgrade", true)]
        [SerializeField] private UnitUpgradeStat _unitUpgradeStat;
        
        [ConditionalHide("_isAccountUpgrade", true)]
        [SerializeField] private AccountUpgradeStat _accountUpgradeStat;
        
        [ConditionalHide("_isUnlockUnit", true)]
        [SerializeField] private UnitUnlock _unitUnlock;
    }

    [System.Serializable]
    public class UnitUpgradeStat
    {
        [SerializeField] private UnitConfig _unitConfig;
        [SerializeField] private float _healthIncrease;
    }
    
    [System.Serializable]
    public class AccountUpgradeStat
    {
    }
    
    [System.Serializable]
    public class UnitUnlock
    {
    }
}