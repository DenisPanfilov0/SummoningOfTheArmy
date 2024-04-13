using UnityEngine;

public class Warrior : AllyUnit
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _spellRadius;

    public void Init(int healt, float damageValue, float attackRadius, float spellRadius)
    {
        Init(healt, damageValue);
        _attackRadius = attackRadius;
        _spellRadius = spellRadius;
    }
    
    public void Attack()
    {
        //TODO: прописать в классе с атаками спелл
    }
}