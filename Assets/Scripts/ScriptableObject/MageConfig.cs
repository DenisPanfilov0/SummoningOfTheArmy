using UnityEngine;

[CreateAssetMenu(fileName = "MageConfig", menuName = "Configs/Mage Config", order = 2)]
public class MageConfig : UnitConfig
{
    [Header("Mage Specific Characteristics")]
    [SerializeField] private float _spellRadius;

    public float SpellRadius => _spellRadius;
}
