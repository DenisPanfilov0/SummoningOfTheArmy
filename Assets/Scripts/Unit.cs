using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected float _movementSpeed;

    public abstract void Move();
}
