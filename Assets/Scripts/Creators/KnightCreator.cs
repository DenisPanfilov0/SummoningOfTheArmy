using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

public class KnightCreator : AllyCreator
{
    public KnightCreator(UnitConfig knightConfig)
    {
        _unitConfig = knightConfig;
    }

    public override AllyUnit FactoryMethod(Transform parent)
    {
        var assetProvider = new AssetProvider();
        var go = assetProvider.Instantiate("Prefabs/KnightPrefab", parent);
        var unitComponent = go.AddComponent<KnightUnit>();
        unitComponent.Init(_unitConfig.Health, _unitConfig.MovementSpeed, _unitConfig.Damage, _unitConfig.AttackSpeed);
        
        var circleCollider = go.GetComponent<CircleCollider2D>();
        if (circleCollider != null)
        {
            circleCollider.radius = _unitConfig.AttackRadius;
        }
        return unitComponent;
    }
}