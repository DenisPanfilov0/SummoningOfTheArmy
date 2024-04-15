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
        Debug.Log($"Союзник {name} встретил врага {other.name}");

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
            _enemiesInAttackRange.Remove(other.GetComponent<EnemyUnit>());
        }

        if (_enemiesInAttackRange.Count == 0)
        {
            _animator.SetBool("IsAttacking", false);

            _animator.SetFloat("Speed", _movementSpeed);
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void Attack()
    {
        CheckForNewEnemies();
        
        if (_enemiesInAttackRange.Count > 0)
        {
            if (_timeSinceLastAttack >= _attackSpeed)
            {
                _animator.SetBool("IsAttacking", true);

                EnemyUnit nearestEnemy = _enemiesInAttackRange
                    .OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).FirstOrDefault();
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
    
    private void CheckForNewEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _attackRange);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy") && !_enemiesInAttackRange.Contains(collider.GetComponent<EnemyUnit>()))
            {
                _enemiesInAttackRange.Add(collider.GetComponent<EnemyUnit>());
            }
        }
    }

    private void Update()
    {
        if (IsDead()) Destroy(gameObject);
        _timeSinceLastAttack += Time.unscaledDeltaTime;

        _enemiesInAttackRange.RemoveAll(e => e == null || e.IsDead());

        if (_enemiesInAttackRange.Count == 0)
        {
            Move();
        }
        else
        {
            Attack();
        }
    }
}