using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CodeBase;
using UnityEngine;

public class AllyUnit : Unit
{
    protected List<EnemyUnit> _enemiesInAttackRange = new List<EnemyUnit>();
    
    private EnemyPortalHandler _enemyBase;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Союзник {name} встретил врага {other.name}");

        if (other.CompareTag("Enemy"))
        {
            _animator.SetFloat("Speed", 0);

            _enemiesInAttackRange.Add(other.GetComponent<EnemyUnit>());
        }
        else if (other.CompareTag("EnemyBase"))
        {
            _animator.SetFloat("Speed", 0);
            _enemyBase = other.GetComponent<EnemyPortalHandler>();
            Attack();
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
            AttackNearestEnemy();
        }
        else if (_enemyBase != null)
        {
            AttackEnemyBase();
        }
        else
        {
            Move();
        }
    }

    private void AttackEnemyBase()
    {
        if (_timeSinceLastAttack >= _attackSpeed)
        {
            _animator.SetBool("IsAttacking", true);

            _enemyBase.TakeDamage(_damageValue);
            Debug.Log($"{name} использовал атаку, нанеся {_damageValue} урона вражеской базе.");
            _timeSinceLastAttack = 0f;
        }
    }

    private void AttackNearestEnemy()
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

    public override void Move()
    {
        if (_enemiesInAttackRange.Count == 0 && _enemyBase == null)
        {
            if (transform.rotation.y != 0)
            {
                transform.Translate(Vector3.left * (_movementSpeed * Time.deltaTime));
            }
            else
            {
                transform.Translate(Vector3.right * (_movementSpeed * Time.deltaTime));
            }
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

        if (_enemiesInAttackRange.Count == 0 && _enemyBase == null)
        {
            Move();
        }
        else
        {
            Attack();
        }
    }
}