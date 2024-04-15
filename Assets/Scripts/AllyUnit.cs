using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyUnit : Unit
{
    protected List<EnemyUnit> _enemiesInAttackRange = new List<EnemyUnit>();

    protected void Init(float health, float movementSpeed)
    {
        _health = health;
        _movementSpeed = movementSpeed;
    }

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
}
