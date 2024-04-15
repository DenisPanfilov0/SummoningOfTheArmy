using UnityEngine;

namespace CodeBase.Config
{
    [CreateAssetMenu(fileName = "UnitUpgrade", menuName = "Configs/Unit Upgrade")]
    public class UnitUpgrade : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _currenUpgradeLevel;
        [SerializeField] private int _maxUpgradeLevel;
        [SerializeField] private float _priceItem;
        [SerializeField] private float _priceModifier;
        [SerializeField] private float _priceModifierDecrement;
        [SerializeField, Multiline] private string _description;


        public string Name => _name;
        public int MaxUpgradeLevel => _maxUpgradeLevel;
        public float PriceModifierDecrement => _priceModifierDecrement;

        public string Description => _description;

        public float PriceModifier
        {
            get => _priceModifier;
            set => _priceModifier = value;
        }

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
        public UnitUpgradeStat UnitUpgradeCharacteristic => _unitUpgradeStat; 
        
        
        [ConditionalHide("_isAccountUpgrade", true)]
        [SerializeField] private AccountUpgradeStat _accountUpgradeStat;
        public AccountUpgradeStat AccountUpgradeStat => _accountUpgradeStat;


        [ConditionalHide("_isUnlockUnit", true)]
        [SerializeField] private UnitUnlock _unit;
        public UnitUnlock Unit => _unit;
        
        
        public bool IsUnitUpgrade => _isUnitUpgrade;
        public bool IsAccountUpgrade => _isAccountUpgrade;
        public bool IsUnlockUnit => _isUnlockUnit;
    }

    [System.Serializable]
    public class UnitUpgradeStat
    {
        [SerializeField] private UnitConfig _unitConfig;
        [SerializeField] private float _healthIncrease;
        [SerializeField] private float _damageIncrease;

        public UnitConfig Unit => _unitConfig;
        public float HealthIncrease => _healthIncrease;
        public float DamageIncrease => _damageIncrease;
    }
    
    [System.Serializable]
    public class AccountUpgradeStat
    {
        //[SerializeField] private MainPlayerConfig _config;
        [SerializeField] private float _healthIncrease;

        //public MainPlayerConfig Config => _config;
        public float HealthIncrease => _healthIncrease;
    }
    
    [System.Serializable]
    public class UnitUnlock
    {
        [SerializeField] private UnitConfig _config;
        
        public UnitConfig Config => _config;
    }
    
    
    public class ConditionalHideAttribute : PropertyAttribute {
        public string conditionalSourceField;
        public bool hideInInspector;
        public bool invertCondition;

        public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector = false, bool invertCondition = false) {
            this.conditionalSourceField = conditionalSourceField;
            this.hideInInspector = hideInInspector;
            this.invertCondition = invertCondition;
        }
    }
}