using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

public class MageCreator : AllyCreator
{
    private MageConfig _mageConfig;
    
    public MageCreator(MageConfig mageConfig)
    {
        _mageConfig = mageConfig;
    }
    
    public override AllyUnit FactoryMethod(Transform parent)
    {
        var assetProvider = new AssetProvider();
        var go = assetProvider.Instantiate("Prefabs/MagePrefab", parent);
        var unitComponent = go.AddComponent<MageUnit>();
        unitComponent.Init(_mageConfig.Health, _mageConfig.MovementSpeed, _mageConfig.Damage, _mageConfig.AttackSpeed);
        
        var circleCollider = go.GetComponent<CircleCollider2D>();
        if (circleCollider != null)
        {
            circleCollider.radius = _mageConfig.SpellRadius;
        }
        return unitComponent;
    }
}