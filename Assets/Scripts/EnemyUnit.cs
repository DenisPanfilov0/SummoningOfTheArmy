using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CodeBase;
using UnityEngine;

public class EnemyUnit : Unit
{
    protected List<AllyUnit> _alliesInAttackRange = new List<AllyUnit>();
    
    private HeroPortalHandler _enemyBase;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Враг {name} встретил союзника {other.name}");
        if (other.CompareTag("Ally"))
        {
            _animator.SetFloat("Speed", 0);

            _alliesInAttackRange.Add(other.GetComponent<AllyUnit>());
        }
        else if (other.CompareTag("AllyBase"))
        {
            _animator.SetFloat("Speed", 0);
            _enemyBase = other.GetComponent<HeroPortalHandler>();
            Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ally"))
        {
            _alliesInAttackRange.Remove(other.GetComponent<AllyUnit>());
        }

        if (_alliesInAttackRange.Count == 0)
        {
            _animator.SetBool("IsAttacking", false);
            
            _animator.SetFloat("Speed", _movementSpeed);
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void Attack()
    {
        CheckForNewEnemies();
        
        if (_alliesInAttackRange.Count > 0)
        {
            AttackNearestEnemy();
        }
        else if (_enemyBase != null)
        {
            AttackEnemyBase();
        }
        else
        {
            Debug.Log($"Нет врагов в радиусе атаки {name}.");
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

            AllyUnit nearestEnemy = _alliesInAttackRange
                .OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).FirstOrDefault();
            nearestEnemy.Health -= _damageValue;
            Debug.Log($"{name} использовал атаку, нанеся {_damageValue} урона {nearestEnemy.name}.");
            _timeSinceLastAttack = 0f;
        }
    }
    
    public override void Move()
    {
        if (_alliesInAttackRange.Count == 0 && _enemyBase == null) 
        {
            // transform.Translate(Vector3.left * (_movementSpeed * Time.deltaTime));
            if (transform.rotation.y != 0)
            {
                transform.Translate(Vector3.right * (_movementSpeed * Time.deltaTime));
            }
            else
            {
                transform.Translate(Vector3.left * (_movementSpeed * Time.deltaTime));
            }
        }
        else
        {
            transform.position = transform.position;
            Attack();
        }
    }
    
    private void Update()
    {
        if (IsDead()) Destroy(gameObject);
        _timeSinceLastAttack += Time.unscaledDeltaTime;

        _alliesInAttackRange.RemoveAll(e => e == null || e.IsDead());

        if (_alliesInAttackRange.Count == 0 && _enemyBase == null)
        {
            Move();
        }
        else
        {
            Attack();
        }
    }
    
    private void CheckForNewEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _attackRange);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Ally") && !_alliesInAttackRange.Contains(collider.GetComponent<AllyUnit>()))
            {
                _alliesInAttackRange.Add(collider.GetComponent<AllyUnit>());
            }
        }
    }
}
