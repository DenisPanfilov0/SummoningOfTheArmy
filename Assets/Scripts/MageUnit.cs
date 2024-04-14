using System.Linq;
using UnityEngine;

public class MageUnit : AllyUnit, IAttackingUnit
{
    private float _attackValue;
    private float _attachSpeed;

    public void Init(float healt, float movementSpeed, float damageValue)
    {
        Init(healt, movementSpeed);
        _attackValue = damageValue;
    }
    
    public void Attack()
    {
        if (_enemiesInSpellRange.Count > 0)
        {
            EnemyUnit nearestEnemy = _enemiesInSpellRange.OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).FirstOrDefault();
            nearestEnemy._health -= _attackValue;
            Debug.Log($"Маг использовал заклинание, нанеся {_attackValue} урона {nearestEnemy.name}.");
        }
        else
        {
            Debug.Log("Нет врагов в радиусе заклинания мага.");
            Move();
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
            Attack();
        }
    }

    private void Update()
    {
        Move();
    }
}