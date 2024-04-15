using CodeBase.EditorTool;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitConfig", menuName = "Configs/Unit Config", order = 1)]
public class UnitConfig : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _unitName;
    [SerializeField] private Sprite _unitSprite;
    
    public int ID => _id;
    public Sprite UnitSprite => _unitSprite;


    
    [Header("Main Characteristics")]
    [SerializeField] private float _damage;
    [SerializeField] private float _health;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _attackSpeed;
    
    public float Damage => _damage;
    public float Health => _health;
    public float MovementSpeed => _movementSpeed;
    public float AttackSpeed => _attackSpeed;


    
    [Header("")] 
    [Header("Base Characteristics")] 
    [SerializeField] private bool _isBaseStats = false;
    
    [ConditionalHide("_isBaseStats", true)]
    [SerializeField] private float _baseDamage;
    
    [ConditionalHide("_isBaseStats", true)]
    [SerializeField] private float _baseHealth;


    
    [Header("")] 
    [Header("Constant Increase Characteristic")]
    [SerializeField] private bool _isConstantStats = false;
    
    [ConditionalHide("_isConstantStats", true)]
    [SerializeField] private float _constantDamageIncrease;
    
    [ConditionalHide("_isConstantStats", true)]
    [SerializeField] private float _constantHealthIncrease;

    
    
    [Header("")] 
    [Header("Percentage Increase Characteristics")] 
    [SerializeField] private bool _isPercentageStats = false;

    [ConditionalHide("_isPercentageStats", true)]
    [SerializeField] private float _percentageDamageIncrease;

    [ConditionalHide("_isPercentageStats", true)]
    [SerializeField] private float _percentageHealthIncrease;


    //[SerializeField] private float _healingBonus;

    //[SerializeField] private UpgradeConfig _upgrade;

    public void DamageCalculated()
    {
        _health = (_baseHealth + _constantHealthIncrease) * (_percentageHealthIncrease / 100 + 1);
    }
}