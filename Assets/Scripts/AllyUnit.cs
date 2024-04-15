using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AllyUnit : Unit
{
    protected List<EnemyUnit> _enemiesInAttackRange = new List<EnemyUnit>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _animator.SetFloat("Speed", 0);

            _enemiesInAttackRange.Add(other.GetComponent<EnemyUnit>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _animator.SetBool("IsAttacking", false);
            
            _animator.SetFloat("Speed", _movementSpeed);

            _enemiesInAttackRange.Remove(other.GetComponent<EnemyUnit>());
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void Attack()
    {
        if (_enemiesInAttackRange.Count > 0)
        {
            if (_timeSinceLastAttack >= _attackSpeed)
            {
                _animator.SetBool("IsAttacking", true);

                EnemyUnit nearestEnemy = _enemiesInAttackRange.OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).FirstOrDefault();
                nearestEnemy.Health -= _damageValue;
                Debug.Log($"{name} использовал атаку, нанеся {_damageValue} урона {nearestEnemy.name}.");
                _timeSinceLastAttack = 0f;
            }
        }
        else
        {
            Debug.Log($"Нет врагов в радиусе атаки {name}.");
            Move();
        }
    }
}
