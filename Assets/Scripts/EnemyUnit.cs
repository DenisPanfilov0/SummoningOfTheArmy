using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class EnemyUnit : Unit
{
    protected List<AllyUnit> _alliesInAttackRange = new List<AllyUnit>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ally"))
        {
            _animator.SetFloat("Speed", 0);

            _alliesInAttackRange.Add(other.GetComponent<AllyUnit>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ally"))
        {
            _animator.SetBool("IsAttacking", false);
            
            _animator.SetFloat("Speed", _movementSpeed);

            _alliesInAttackRange.Remove(other.GetComponent<AllyUnit>());
        }
    }
    
    public void Attack()
    {
        if (_alliesInAttackRange.Count > 0)
        {
            if (_timeSinceLastAttack >= _attackSpeed)
            {
                _animator.SetBool("IsAttacking", true);

                AllyUnit nearestEnemy = _alliesInAttackRange.OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).FirstOrDefault();
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
