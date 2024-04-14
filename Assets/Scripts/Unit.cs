using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] public float _health;
    [SerializeField] protected float _movementSpeed;

    public abstract void Move();
}
