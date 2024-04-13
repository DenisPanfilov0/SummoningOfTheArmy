using UnityEngine;

public class MageUnit : AllyUnit, IAttackingUnit
{
    [SerializeField] private float _attackValue;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _spellRadius;

    public void Init(int healt, float movementSpeed, float damageValue, float attackRadius, float spellRadius)
    {
        Init(healt, movementSpeed);
        _attackValue = damageValue;
        _attackRadius = attackRadius;
        _spellRadius = spellRadius;
    }
    
    public void Attack(Unit target)
    {
        //TODO: прописать в классе с атаками спелл
        Debug.Log("Маг атакует");
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }
}