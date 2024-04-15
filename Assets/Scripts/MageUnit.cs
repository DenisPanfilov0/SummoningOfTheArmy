using System.Linq;
using UnityEngine;

public class MageUnit : AllyUnit, IAttackingUnit
{
    // ReSharper disable Unity.PerformanceAnalysis
    public void Attack()
    {
        if (_enemiesInAttackRange.Count > 0)
        {
            if (_timeSinceLastAttack >= _attackSpeed)
            {
                _animator.SetBool("IsAttacking", true);

                //EnemyUnit nearestEnemy = _enemiesInAttackRange.OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).FirstOrDefault();
                //nearestEnemy.Health -= _damageValue;
                Debug.Log($"Маг использовал заклинание, нанеся {_damageValue} урона {"" /*nearestEnemy.name*/}.");
                _timeSinceLastAttack = 0f;
            }
        }
        else
        {
            Debug.Log("Нет врагов в радиусе заклинания мага.");
            Move();
        }
    }

    public override void Move()
    {
        if (_enemiesInAttackRange.Count == 0)
        {
            transform.Translate(Vector3.right * (_movementSpeed * Time.deltaTime));
        }
        else
        {
            transform.position = transform.position;
            Attack();
        }
    }

    private void Update()
    {
        _timeSinceLastAttack += Time.unscaledDeltaTime;
        Move();
    }
}