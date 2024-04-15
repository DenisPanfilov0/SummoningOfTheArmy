using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

public class MageCreator : AllyCreator
{
   public MageCreator(UnitConfig mageConfig)
    {
        _unitConfig = mageConfig;
    }
    
    public override AllyUnit FactoryMethod(Transform parent)
    {
        var assetProvider = new AssetProvider();
        var go = assetProvider.Instantiate("Prefabs/MagePrefab", parent);
        var unitComponent = go.AddComponent<MageUnit>();
        unitComponent.Init(_unitConfig.Health, _unitConfig.MovementSpeed, _unitConfig.Damage, _unitConfig.AttackSpeed, _unitConfig.AttackRadius);
        
        var circleCollider = go.GetComponent<CircleCollider2D>();
        if (circleCollider != null)
        {
            circleCollider.radius = _unitConfig.AttackRadius;
        }
        return unitComponent;
    }
}