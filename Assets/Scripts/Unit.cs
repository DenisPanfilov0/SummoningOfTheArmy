using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected float _health;
    protected float _movementSpeed;
    protected Animator _animator;

    public float Health
    {
        get => _health;
        set => _health = value;
    }

    public float MovementSpeed
    {
        get => _movementSpeed;
        set => _movementSpeed = value;
    }

    public Animator Animator
    {
        get => _animator;
        set => _animator = value;
    }

    protected void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public abstract void Move();
}
