using UnityEngine;
using CodeBase.EditorTool;
using UnityEngine.Serialization;

namespace CodeBase.Config
{
    [CreateAssetMenu(fileName = "UnitUpgrade", menuName = "Configs/Unit Upgrade")]
    public class UnitUpgrade : ScriptableObject
    {
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