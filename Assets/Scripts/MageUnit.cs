using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MageUnit : AllyUnit, IAttackingUnit
{
    [SerializeField] private float _attackValue;
    [SerializeField] private float _spellRadius;

    public void Init(int healt, float movementSpeed, float damageValue, float spellRadius)
    {
        Init(healt, movementSpeed);
        _attackValue = damageValue;
        _spellRadius = spellRadius;
    }
    
    public void Attack()
    {
        
        if (_enemiesInSpellRange.Count > 0)
        {
            EnemyUnit nearestEnemy = _enemiesInSpellRange.OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).FirstOrDefault();
            nearestEnemy._health -= _attackValue;
            Debug.Log($"Маг использовал заклинание, нанеся {_attackValue * 0.5f} урона {nearestEnemy.name}.");
        }
        else
        {
            Debug.Log("Нет врагов в радиусе заклинания мага.");
        }
    }

    public override void Move()
    {
        if (_enemiesInSpellRange.Count == 0)
        {
            transform.Translate(Vector3.right * _movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = transform.position;
        }
    }

    private void Update()
    {
        Move();
        Attack();
    }
}