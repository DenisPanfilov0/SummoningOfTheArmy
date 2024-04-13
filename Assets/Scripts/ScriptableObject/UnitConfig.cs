using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "ScriptableObjects/UnitData", order = 1)]
public class UnitConfig : ScriptableObject
{
    public int id;
    public string unitName;
    public GameObject unitPrefab;
    public int health;
    public float movementSpeed;
    
    [Header("Damage")]
    public float damage;

    [Header("Healing")] 
    public float healingBonus;
}