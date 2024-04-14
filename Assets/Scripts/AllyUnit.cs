using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyUnit : Unit
{
    protected List<EnemyUnit> _enemiesInSpellRange = new List<EnemyUnit>();

    protected void Init(float health, float movementSpeed)
    {
        _health = health;
        _movementSpeed = movementSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ЗАШЛИ");
        if (other.CompareTag("Enemy"))
        {
            _enemiesInSpellRange.Add(other.GetComponent<EnemyUnit>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemiesInSpellRange.Remove(other.GetComponent<EnemyUnit>());
        }
    }
}
