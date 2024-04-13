using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyUnit : MonoBehaviour, IUnits
{
    [SerializeField] protected int _health;
    [SerializeField] protected float _attackValue;
    //убрать атаку и добавить скорость передвижения

    protected void Init(int health, float attackValue)
    {
        _health = health;
        _attackValue = attackValue;
    }
}
