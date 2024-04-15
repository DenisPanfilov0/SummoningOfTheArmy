using CodeBase.EditorTool;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "UnitConfig", menuName = "Configs/Unit Config", order = 1)]
public class UnitConfig : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _unitName;
    [SerializeField] private Sprite _image;
    [SerializeField] private float _costSummoner;
    [SerializeField] private bool _isUsedDeca;

    
    public int Id => _id;
    public Sprite Image => _image;
    public float CostSummoner => _costSummoner;
    
    public bool IsUsedDeca
    {
        get => _isUsedDeca;
        set => _isUsedDeca = value;
    }


    
    [Header("Main Characteristics")]
    [SerializeField] private float _damage;
    [SerializeField] private float _health;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackRadius;
    
    public float Damage => _damage;
    public float Health => _health;
    public float MovementSpeed => _movementSpeed;
    public float AttackSpeed => _attackSpeed;
    public float AttackRadius => _attackRadius;


    
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
    
    
    
    
    
    
    

    //public Sprite Image => _image;

    /*public HeroConfig(int id = 0, int health = 0, int damage = 0)
    {
        _id = id;
        _health = health; 
        _damage = damage;
    }*/
    
    


    //[SerializeField] private float _healingBonus;

    //[SerializeField] private UpgradeConfig _upgrade;

    public void ConstantStatIncrease(float damage = 0, float health = 0)
    {
        _constantDamageIncrease += damage;
        _constantHealthIncrease += health;
    }
    
    public void StatsCalculate()
    {
        _damage = (_baseDamage + _constantDamageIncrease) * (_percentageDamageIncrease / 100 + 1);
        _health = (_baseHealth + _constantHealthIncrease) * (_percentageHealthIncrease / 100 + 1);
    }
}