using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected float _health;
    protected float _movementSpeed;
    protected float _damageValue;
    protected float _attackSpeed;
    protected float _attackRange;
    protected Animator _animator;

    protected float _timeSinceLastAttack = 0f;
    

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

    public float AttackSpeed
    {
        get => _attackSpeed;
        set => _attackSpeed = value;
    }
    
    public float AttackRange
    {
        get => _attackRange;
        set => _attackRange = value;
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
    
    public void Init(float health, float movementSpeed, float damageValue, float attackPerSecond, float attackRange)
    {
        _health = health;
        _movementSpeed = movementSpeed;
        _damageValue = damageValue;
        _attackSpeed = 1f / attackPerSecond;
        _attackRange = attackRange;
    }

    public abstract void Move();

    protected bool IsDead()
    {
        if (_health <= 0)
        {
            return true;
        }

        return false;
    }
    
    private void Update()
    {
        if (IsDead()) Destroy(gameObject);
        _timeSinceLastAttack += Time.unscaledDeltaTime;
        Move();
    }
}