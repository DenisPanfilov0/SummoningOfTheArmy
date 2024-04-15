using System.Linq;
using UnityEngine;

public class MageUnit : AllyUnit, IAttackingUnit
{
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

    
}