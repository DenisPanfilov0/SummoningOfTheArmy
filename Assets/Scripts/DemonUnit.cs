using System.Linq;
using UnityEngine;

public class DemonUnit : EnemyUnit, IAttackingUnit
{
    public override void Move()
    {
        if (_alliesInAttackRange.Count == 0)
        {
            transform.Translate(Vector3.left * (_movementSpeed * Time.deltaTime));
        }
        else
        {
            transform.position = transform.position;
            Attack();
        }
    }
}