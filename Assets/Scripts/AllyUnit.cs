using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyUnit : Unit
{
    protected void Init(int health, float movementSpeed)
    {
        _health = health;
        _movementSpeed = movementSpeed;
    }
}
