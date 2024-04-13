using UnityEngine;

public class Healer : AllyUnit
{
    [SerializeField] private float _healValue;
    
    public void Init(int healt, float damageValue, float healValue)
    {
        Init(healt, damageValue);
        _healValue = healValue;
    }
}